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
            Destroy(this.gameObject);

        int minID = this.findClosestPlayer();

        if (minID > -1)
            agent.SetDestination(playerList[minID].transform.position);


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

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("HIT1");

        if (collision.gameObject.tag == "Player")
        {
            //Debug.Log("HIT2");

            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            
            if (playerController.PlayerId == this.ownerId)
                return;

            //Debug.Log("HIT3");

            if (this.skill.SkillID == 0)
                playerController.IvySkillEffect(skill.SkillDuration);
            else if (this.skill.SkillID == 1)
                playerController.OnionSkillEffect(skill.SkillDuration);

            Destroy(this.gameObject);
        }
    }

}
