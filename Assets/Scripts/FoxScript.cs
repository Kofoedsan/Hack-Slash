using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class FoxScript : MonoBehaviour {

    public Transform player;
    private int ChasingSpeedHash;

    private NavMeshAgent navMeshAgent;
    private float ChasingSpeed;
    private Animator animator;
    [SerializeField] private float RangeRun;
    [SerializeField] private float RangeWalk;
    private float acceleration = 1.0f;
    private float decceleration = 1.0f;
    private float stop;
    [SerializeField] private float RunSpeed;
    [SerializeField] private float WalkSpeed;

    private bool sitting = false;

    void Start(){

        navMeshAgent = GetComponent<NavMeshAgent>();
        stop = navMeshAgent.stoppingDistance;
        ChasingSpeedHash = Animator.StringToHash("Mix");
        animator = GetComponent<Animator>();


    }


    void Update(){


        if (Vector3.Distance(transform.position, player.position) < RangeRun && Vector3.Distance(transform.position, player.position) > RangeWalk) {
            sitting = false;


            if (ChasingSpeed < 1.0f) {
                ChasingSpeed += Time.deltaTime * acceleration;
            } else {
                ChasingSpeed -= Time.deltaTime * decceleration;
            }

            animator.SetFloat(ChasingSpeedHash, ChasingSpeed);

            navMeshAgent.speed = RunSpeed;
            Chase();

        }

        if (Vector3.Distance(transform.position, player.position) < RangeWalk && Vector3.Distance(transform.position, player.position) > stop) {
            sitting = false;

            if (ChasingSpeed > 0.5f) {
                ChasingSpeed -= Time.deltaTime * decceleration;
            } else {
                ChasingSpeed += Time.deltaTime * acceleration;
            }


            animator.SetFloat(ChasingSpeedHash, ChasingSpeed);


            navMeshAgent.speed = WalkSpeed;
            Chase();


        }
        if (Vector3.Distance(transform.position, player.position) < stop) {

            if (ChasingSpeed > 0.05f&& !sitting) {
                ChasingSpeed -= Time.deltaTime * decceleration;
            }

            if (ChasingSpeed < 0.05f){
                sitting = true; 
                ChasingSpeed = 0.0f;
            }

            animator.SetFloat(ChasingSpeedHash, ChasingSpeed);
            navMeshAgent.speed = 0.0f;

        }




    }

    void Chase() {
        navMeshAgent.SetDestination(player.position);
    }
}
