using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour {
    
    private NavMeshAgent navMeshAgent;
    public Transform Player;

    [SerializeField] private float aggroRangeRun;
    [SerializeField] private float RunSpeed;
    [SerializeField] private float WalkSpeed;
    [SerializeField] private float aggroRangeWalk;



    void Start() {

              navMeshAgent = GetComponent<NavMeshAgent>();  
    }

    void Update() {
       if (navMeshAgent.enabled == true) {

       if (Vector3.Distance(transform.position, Player.position) < aggroRangeRun) {
           navMeshAgent.speed = RunSpeed;
                Chase();
            }

       if (Vector3.Distance(transform.position, Player.position) < aggroRangeWalk) {
           navMeshAgent.speed = WalkSpeed;
                Chase();
           }

        }
    }

    void Chase() {
        navMeshAgent.SetDestination(Player.position);
    }


}
