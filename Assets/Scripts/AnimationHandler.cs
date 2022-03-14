using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AnimationHandler : MonoBehaviour
{
    private NavMeshAgent agent;
    private Animator animator;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

  
    void Update()
    {

        animator.SetFloat("Speed", agent.desiredVelocity.magnitude);

    }
}
