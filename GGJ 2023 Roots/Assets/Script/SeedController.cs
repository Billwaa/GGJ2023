using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class SeedController : MonoBehaviour
{
    UnityEngine.AI.NavMeshAgent agent;

    [SerializeField]
    Transform target;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target.position);
    }
}
