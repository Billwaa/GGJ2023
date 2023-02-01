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

    // Start is called before the first frame update
    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        playerController = playerManager.playerList;

        float minDist = 999;
        int minID = -1;

        for (int i = 0; i < playerController.Count; i++)
        {
            float mag = (playerController[i].transform.position - this.transform.position).magnitude;

            if (mag < minDist)
            {
                minDist = mag;
                minID = i;
            }
        }

        if (minID > -1)
            agent.SetDestination(playerController[minID].transform.position);
    }
}
