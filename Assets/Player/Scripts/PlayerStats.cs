using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour {

    [SerializeField] public float maxHealth = 100;
    public float currentHealth;
    [SerializeField] public float allPillars = 3;
    public float currentPillars;
    public bool isDead;

    CharacterController controller;
    Animator anim;
    ThirdPersonMovement movement;
    Collider[] rigColliders;
    Rigidbody[] rigRigidbodies;
    [SerializeField] private AudioSource collectCrystalSound;


    void Start() {
        controller = GetComponent<CharacterController>();
        movement = GetComponent<ThirdPersonMovement>();
        anim = GetComponent<Animator>();
        currentHealth = maxHealth;
        rigColliders = GetComponentsInChildren<Collider>();
        rigRigidbodies = GetComponentsInChildren<Rigidbody>();
        

        foreach (Rigidbody rb in rigRigidbodies) {
            rb.isKinematic = true;
        }
    }

    void Update() {

        if (currentHealth <= 0.0f) {
           isDead = true;
           anim.enabled = false;
            movement.enabled = false;

            foreach (Collider lider in rigColliders) {
                lider.enabled = true;
                controller.enabled = false;
            }

           foreach (Rigidbody rb in rigRigidbodies) {
                rb.isKinematic = false;
            }

            Invoke("ResetMenu", 5);

        }

    }

    void OnTriggerEnter(Collider other)
    {


        if (other.gameObject.CompareTag("Crystal"))
        {
            collectCrystalSound.Play();
            Destroy(other.gameObject);
            currentHealth += 20.00f;
            maxHealth = currentHealth;
        }

        if (other.gameObject.CompareTag("MaxHpCrystal")) {
            //collectCrystalSound.Play();
            Destroy(other.gameObject);
            maxHealth = maxHealth + 20.0f;
        }

        if (other.gameObject.CompareTag("SecretEntrance"))
        {
            currentPillars = currentPillars + 1.0f;
            Destroy(other.gameObject);
        
        }

        if (other.gameObject.CompareTag("SpecialCrystal"))
        {
            Destroy(other.gameObject);
            currentHealth = maxHealth;
            collectCrystalSound.Play();
        }

        if (other.gameObject.CompareTag("Spike"))
        {

            currentHealth = 0.0f;
            
        }

        if (other.gameObject.CompareTag("Saw"))
        {

            currentHealth = 0.0f;

        }

        if (other.gameObject.CompareTag("SwingAxe"))
        {

            currentHealth = 0.0f;

        }

    }

    void ResetMenu() {
        SceneManager.LoadScene(0);
        Cursor.lockState = CursorLockMode.None;

    }

}
