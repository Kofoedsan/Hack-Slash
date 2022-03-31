using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyDeath : MonoBehaviour {
   
    public bool isDead = false;
    public float health;
    private NavMeshAgent agent;
    private Animator anim;
    private EnemyCombat enemyCombat;

    Collider[] rigColliders;
    Rigidbody[] rigRigidbodies;

    private void Start() {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        enemyCombat = GetComponent<EnemyCombat>();
       
        rigColliders = GetComponentsInChildren<Collider>();
        rigRigidbodies = GetComponentsInChildren<Rigidbody>();


    }
    void Update() {
        if (health <= 0.0f) {
            enemyCombat.CanAttack = false;

            //StartCoroutine(RemoveCorpse());

            if (anim.enabled == true) {
                anim.enabled = false;
            }

            if (agent.enabled == true) {
                agent.enabled = false;
            }

            foreach (Collider lider in rigColliders) {
                lider.enabled = true;
            }

            foreach (Rigidbody rb in rigRigidbodies) {
                rb.isKinematic = false;
            }
        }
    }

    IEnumerator RemoveCorpse() {
        yield return new WaitForSeconds(3);
        //Destroy(gameObject);
        isDead = false;
       
    }

}
