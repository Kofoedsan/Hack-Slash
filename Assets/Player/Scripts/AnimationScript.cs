using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour{

    private Animator animator;
    float velocityZ = 0;
    float velocityX = 0;
    [SerializeField] float speedAccelerator = 0f;
    [SerializeField] float sprintSpeed = 0;
    [SerializeField] float speedDeaccelerator = 0;
    void Start(){

        animator = GetComponent<Animator>();
    }


    void Animations() {
        bool forward = Input.GetKey("w");
        bool backward = Input.GetKey("s");
        bool left = Input.GetKey("a");
        bool right = Input.GetKey("d");
        bool sprint = Input.GetKey("left shift");
        bool space = Input.GetKey("space");
        bool mouse0 = Input.GetMouseButtonDown(0);


        if (Input.GetKeyDown(KeyCode.Space)) {
           // animator.SetTrigger("Jump");
            animator.Play("Jump");
        }

        if (mouse0) {
            // animator.SetTrigger("Jump");
            animator.Play("SwordAttack");
        }


        if (forward && velocityZ < 0.5f && !sprint) {
            velocityZ += Time.deltaTime * speedAccelerator;
        }

        if (backward && velocityZ > -0.5f) {
            velocityZ -= Time.deltaTime * speedAccelerator;
        }

        if (left && velocityX > -0.5f) {
            velocityX -= Time.deltaTime * speedAccelerator;
        }

        if (right && velocityX < 0.5f) {
            velocityX += Time.deltaTime * speedAccelerator;
        }

        if (forward && velocityZ < 0.0f) {
            velocityZ = 0.0f;
        }

        if (!left && velocityX < 0.0f) {
            velocityX += Time.deltaTime * speedDeaccelerator;
        }

        if (!right && velocityX > 0.0f) {
            velocityX -= Time.deltaTime * speedDeaccelerator;
        }

        if (!forward && velocityZ > 0.0f) {
            velocityZ -= Time.deltaTime * speedDeaccelerator;
        }

        if (!backward && velocityZ < 0.0f) {
            velocityZ += Time.deltaTime * speedDeaccelerator;
        }

        if (forward && sprint && velocityZ < 2.0f) {
            velocityZ += Time.deltaTime * sprintSpeed;
        }

        if (forward && velocityZ > 0.5f && !sprint) {
            velocityZ -= Time.deltaTime * (speedAccelerator*2f);
        }

        animator.SetFloat("VelocityZ", velocityZ);
        animator.SetFloat("VelocityX", velocityX);


    }


    void Update(){

        Animations();

    }


    void Move() {

       
    }




}
