using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class SeedController : MonoBehaviour
{
    UnityEngine.AI.NavMeshAgent agent;

    [SerializeField]
    Transform target;

    [SerializeField]
    PlayerManager playerManager;

    List<PlayerController> playerController;

    Animator animator;

    bool locked = false;
    int lastPlayerID = -1;

    // Start is called before the first frame update
    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {

        playerController = playerManager.playerList;

        if (!locked)
        {
            this.transform.parent = null;

            if (lastPlayerID != -1)
            {
                playerController[lastPlayerID].hasSeed = false;
                playerController[lastPlayerID].seedController = null;

            }

            agent.enabled = true;

            float minDist = 999;
            int minID = -1;

            for (int i = 0; i < playerController.Count; i++)
            {
                if (playerController[i].isDead || playerController[i].PlayerId == lastPlayerID)
                    continue;

                float mag = (playerController[i].transform.position - this.transform.position).magnitude;

                if (mag < minDist)
                {
                    minDist = mag;
                    minID = i;
                }
            }

            if (minID > -1)
                agent.SetDestination(playerController[minID].transform.position);
            else
                agent.SetDestination(new Vector3(0, 2, 0));
        }
        else
        {
            agent.enabled = false;

            if (playerController[lastPlayerID].isDead)
            {
                locked = false;
            }
        }
       
    }

    public void nextTarget()
    {
        locked = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerController player = collision.gameObject.GetComponent<PlayerController>();
            Debug.Log("collision");
            if (!player.isDead)
                if (player.PlayerId != lastPlayerID)
                {
                    agent.enabled = false;
                    locked = true;
                    lastPlayerID = collision.transform.GetComponent<PlayerController>().PlayerId;
                    player.hasSeed = true;
                    player.seedController = this;
                    player.passCooldownTimer = 5; // 5 sec before pass
                    this.transform.parent = collision.transform;
                    this.transform.localPosition = new Vector3(0, 3.5f, 0);
                    this.transform.rotation = Quaternion.Euler(-90, 0, 0);
                    Debug.Log("hit");
                }
      
        }
    }
}
