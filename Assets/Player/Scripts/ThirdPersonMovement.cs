using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;
    private PauseScript ps;

    public float walkSpeed = 4.0f;
    public float runSpeed = 6.0f;
    public float turnSmoothTime = 0.1f;
    [SerializeField] float jumpheight;
    float turnSmoothVelocity;

    private void Start()
    {
        ps = GameObject.Find("Pause").GetComponent<PauseScript>();
        Debug.Log(ps.counter);
    }


    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0.0f, vertical).normalized;


        if(direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0.0f, angle, 0.0f);

           

            Vector3 moveDirection = Quaternion.Euler(0.0f, targetAngle, 0.0f) * Vector3.forward;


            controller.Move(moveDirection.normalized * walkSpeed * Time.deltaTime);

            if (Input.GetKey(KeyCode.LeftShift))
            {
            controller.Move(moveDirection.normalized * runSpeed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.Space)) {
                if (controller.isGrounded) {

                    controller.Move((Vector3.up * jumpheight) * Time.deltaTime);
                }
            }





        }

        if(ps.counter <= 0) { 

        if (Cursor.lockState == CursorLockMode.None && Input.GetMouseButtonDown(0))
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else if (Cursor.lockState == CursorLockMode.Locked && Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
        }
        }

   }
}
