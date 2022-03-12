using UnityEngine;

public class PlayerStats : MonoBehaviour {

    [SerializeField] float maxHealth = 100;
    public float currentHealth;
    public bool isDead;


    CharacterController controller;
    Animator anim;
    Collider[] rigColliders;
    Rigidbody[] rigRigidbodies;



    void Start() {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        currentHealth = maxHealth;
        rigColliders = GetComponentsInChildren<Collider>();
        rigRigidbodies = GetComponentsInChildren<Rigidbody>();


        foreach (Rigidbody rb in rigRigidbodies) {
            rb.isKinematic = true;
        }
    }

    void Update() {

        if (currentHealth <= 0f) {
            isDead = true;
           anim.enabled = false;

            foreach (Collider lider in rigColliders) {
                lider.enabled = true;
                controller.enabled = false;
            }

           foreach (Rigidbody rb in rigRigidbodies) {
                rb.isKinematic = false;
            }

            
        }

    }
}
