using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour {
    
    private NavMeshAgent navMeshAgent;

    private Animator animator;
    private int ChasingSpeedHash;
    public Transform Player;
    private float ChasingSpeed;

    private float acceleration = 1.0f;
    private float decceleration = 1.0f;

    [SerializeField] private float aggroRangeRun;
    [SerializeField] private float RunSpeed;
    [SerializeField] private float WalkSpeed;
    [SerializeField] private float aggroRangeWalk;


    
    Rigidbody[] rigRigidbodies;



    void Start() {
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        ChasingSpeedHash = Animator.StringToHash("ChasingSpeed");
        rigRigidbodies = GetComponentsInChildren<Rigidbody>();

        foreach (Rigidbody rb in rigRigidbodies) {
            rb.isKinematic = true;
        }
    

}

    void Update() {
        if (navMeshAgent.enabled == true) {

            if (Vector3.Distance(transform.position, Player.position) < aggroRangeRun && Vector3.Distance(transform.position, Player.position) > aggroRangeWalk) {

                if (ChasingSpeed < 1.0f) {
                    ChasingSpeed += Time.deltaTime * acceleration;
                }

                animator.SetFloat(ChasingSpeedHash, ChasingSpeed);

                navMeshAgent.speed = RunSpeed;
                Chase();
            }

            if (Vector3.Distance(transform.position, Player.position) < aggroRangeWalk) {


                if (ChasingSpeed > 0.5f) {
                    ChasingSpeed -= Time.deltaTime * decceleration;
                }


                animator.SetFloat(ChasingSpeedHash, ChasingSpeed);


                navMeshAgent.speed = WalkSpeed;
                Chase();
            }

             if (Vector3.Distance(transform.position, Player.position) > aggroRangeRun) {
                if (ChasingSpeed > 0.0f) {
                     ChasingSpeed -= Time.deltaTime * decceleration;
            }
        

              
               Vector3 MyVector3 = new Vector3 (transform.position.x, transform.position.y, transform.position.z);

               animator.SetFloat(ChasingSpeedHash, ChasingSpeed);
                navMeshAgent.SetDestination(MyVector3);

            }
        }
    }

    void Chase() {
        navMeshAgent.SetDestination(Player.position);
    }


}
