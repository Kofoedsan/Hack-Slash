using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlooatMovement : MonoBehaviour
{

    Animator animator;
    float velocity = 0.0f;
    [SerializeField] private float acceleration = 0.1f;
    [SerializeField] private float decceleration = 0.5f;

    int VelocityHash;

    void Start()
    {
        animator = GetComponent<Animator>();
        VelocityHash = Animator.StringToHash("Velocity");
    }

    void Update()
    {
        bool forwardPressed = Input.GetKey("w");
        bool runPressed = Input.GetKey("left shift");

        if (forwardPressed && velocity < 5.0f)
        {
            velocity += Time.deltaTime * acceleration;
        }

        if (!forwardPressed && velocity > 0.0f)
        {
            velocity -= Time.deltaTime * decceleration;
        }
        if ( velocity < 0.0f)
        {
            velocity = 0.0f;
        }
        animator.SetFloat(VelocityHash, velocity);
    }
}
