using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour {

    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;
    [SerializeField] private float mouseSpeed;


    private float jumpVelocity;
    private float gravity = 10.0f;
    [SerializeField] private float JumpHeight = 10.0f;

    private Vector3 movedir = Vector3.zero;
    private CharacterController controller;


    private void Start(){
        controller = GetComponent<CharacterController>();


    }
    private void Update() {
        Move();
    }

    private void Move(){

        float h = mouseSpeed * Input.GetAxis("Mouse X");
       


        if (controller.isGrounded) {
           jumpVelocity = -gravity * Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.Space)) {
                jumpVelocity = JumpHeight;

            } else {
                jumpVelocity -= gravity * Time.deltaTime;
            }

        }

        movedir.x = Input.GetAxis("Horizontal");
        movedir.z = Input.GetAxis("Vertical");
        movedir.y = jumpVelocity;


        movedir = transform.TransformDirection(movedir);


         if (!Input.GetKey(KeyCode.LeftShift)){
            movedir.x *= walkSpeed;
            movedir.z *= walkSpeed;
          } else if (Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D)) {
            movedir.x *= runSpeed;
            movedir.z *= runSpeed;
         } else if (Input.GetKey(KeyCode.S)) {
            movedir.x *= walkSpeed;
            movedir.z *= walkSpeed;
        } else if (Input.GetKey(KeyCode.A)) {
            movedir.x *= walkSpeed;
            movedir.z *= walkSpeed;
        } else if (Input.GetKey(KeyCode.D)) {
            movedir.x *= walkSpeed;
            movedir.z *= walkSpeed;
        }


        if (Cursor.lockState == CursorLockMode.None && Input.GetMouseButtonDown(0)) {
            Cursor.lockState = CursorLockMode.Locked;
        } else if (Cursor.lockState == CursorLockMode.Locked && Input.GetKeyDown(KeyCode.Escape)) {
            Cursor.lockState = CursorLockMode.None;
        }

        if (controller.enabled == true) {
            transform.Rotate(0, h, 0);
            controller.Move(movedir * Time.deltaTime);
        }
    }

}