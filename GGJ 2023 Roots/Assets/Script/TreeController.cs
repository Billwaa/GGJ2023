using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TreeController : MonoBehaviour
{
    UnityEngine.AI.NavMeshAgent agent;

    [SerializeField]
    Transform target;

    Animator animator;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target.position);


        if (agent.velocity.magnitude > 0.5)
        {
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }
    }
}
