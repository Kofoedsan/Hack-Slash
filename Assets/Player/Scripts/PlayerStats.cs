using UnityEngine;
using UnityEngine.AI;

public class PlayerStats : MonoBehaviour {

    [SerializeField] float maxHealth = 100;
    public float currentHealth;
    public bool isDead;

    NavMeshAgent agent;
    CharacterController controller;
    Animator anim;
    ThirdPersonMovement movement;
    Collider[] rigColliders;
    Rigidbody[] rigRigidbodies;
    [SerializeField] private AudioSource collectCrystalSound;


    void Start() {
        controller = GetComponent<CharacterController>();
        movement = GetComponent<ThirdPersonMovement>();
        agent = GetComponent<NavMeshAgent>();
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
           agent.enabled = false;
            movement.enabled = false;

            foreach (Collider lider in rigColliders) {
                lider.enabled = true;
                controller.enabled = false;
            }

           foreach (Rigidbody rb in rigRigidbodies) {
                rb.isKinematic = false;
            }

            
        }

    }

    void OnTriggerEnter(Collider other)
    {


        if (other.gameObject.CompareTag("Crystal"))
        {
            collectCrystalSound.Play();
            Destroy(other.gameObject);
            currentHealth += 20.00f;
        }

        if (other.gameObject.CompareTag("SecretEntrance"))
        {

            Destroy(other.gameObject);
        
        }

        if (other.gameObject.CompareTag("SpecialCrystal"))
        {
            Destroy(other.gameObject);
            currentHealth = maxHealth;
            collectCrystalSound.Play();
        }
    }


}
