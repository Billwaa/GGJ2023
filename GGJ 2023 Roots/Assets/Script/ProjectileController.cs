using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ProjectileController : MonoBehaviour
{
    public Skill skill = null;
    public float destroyTimer = 0;
    public float ownerId = -1;

    public List<PlayerController> playerList;

    private NavMeshAgent agent;

    public GameObject explosionObj;
    public GameObject meshObj;

    void Start()
    {
        destroyTimer = skill.ProjectileFlightTime;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        destroyTimer -= Time.deltaTime;
        
        if (destroyTimer < 0)
        {
            explosionObj.SetActive(true);
            meshObj.SetActive(false);
            checkDestroyEvent();
            agent.speed = 0;

        }
        else
        {

            int minID = this.findClosestPlayer();

            if (minID > -1)
                agent.SetDestination(playerList[minID].transform.position);
        }




    }

    public int findClosestPlayer()
    {
        float minDist = 999;
        int minID = -1;

        for (int i = 0; i < playerList.Count; i++)
        {
            if (i == ownerId || playerList[i].isDead)
                continue;

            float dist = (this.transform.position - playerList[i].transform.position).magnitude;
            
            if (dist < minDist)
            {
                minDist = dist;
                minID = i;
            }
        }

        return minID;

    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("HIT1");

        if (other.gameObject.tag == "Player")
        {
            //Debug.Log("HIT2");

            PlayerController playerController = other.gameObject.GetComponent<PlayerController>();
            
            if (playerController.PlayerId == this.ownerId || playerController.isDead)
                return;

            //Debug.Log("HIT3");

            if (this.skill.SkillID == 0)
                playerController.IvySkillEffect(skill.SkillEffectTime);
            else if (this.skill.SkillID == 1)
                playerController.OnionSkillEffect(skill.SkillEffectTime);

            explosionObj.SetActive(true);
            meshObj.SetActive(false);
        }
    }

    private void checkDestroyEvent()
    {
        if (explosionObj.activeSelf && !explosionObj.GetComponent<ParticleSystem>().isPlaying )
            Destroy(this.gameObject);

    }

}
