using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyDeath : MonoBehaviour {
   
    public bool isDead = false;
    public float health;
    private NavMeshAgent agent;
    private Animator anim;
    private EnemyCombat enemyCombat;
    private AlienWithSwordCombat enemyCombatSword;

    Collider[] rigColliders;
    Rigidbody[] rigRigidbodies;

    private void Start() {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        enemyCombat = GetComponent<EnemyCombat>();

        enemyCombatSword = GetComponent<AlienWithSwordCombat>();

        rigColliders = GetComponentsInChildren<Collider>();
        rigRigidbodies = GetComponentsInChildren<Rigidbody>();


    }
    void Update() {
        if (health <= 0.0f) {

            try {
                enemyCombat.CanAttack = false;
            } catch {
                enemyCombatSword.CanAttack = false;
            }


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
            isDead = true;
            StartCoroutine(RemoveCorpse());
        }
    }

    IEnumerator RemoveCorpse() {
        yield return new WaitForSeconds(10);
        Destroy(gameObject);
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Spike"))
        {

            health = 0.0f;

        }
    }



}
