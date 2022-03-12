using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyDeath : MonoBehaviour {
   
    public bool isDead = false;
    private NavMeshAgent agent;
    private Animator anim;

    private void Start() {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
       
    }
    void Update() {
        if (isDead == true) {

            //StartCoroutine(RemoveCorpse());

            if (anim.enabled == true) {
                anim.enabled = false;
            }

            if (agent.enabled == true) {
                agent.enabled = false;
            }
        }
    }

    IEnumerator RemoveCorpse() {
        yield return new WaitForSeconds(3);
        //Destroy(gameObject);
        isDead = false;
       
    }

}
