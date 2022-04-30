using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoDimensionalAnimationStateController : MonoBehaviour {
    Animator animator;
    WeaponController weaponController;
    float velocityX = 0.0f;
    float velocityZ = 0.0f;
    [SerializeField] private float acceleration = 2.0f;
    [SerializeField] private float decceleration = 2.0f;
    [SerializeField] private float maximumWalkVelocity = 0.5f;
    [SerializeField] private float maximumRunVelocity = 2.0f;
    [SerializeField] private AudioSource swingSword;

    Transform player;

    // increase performance
    int VelocityZHash;
    int VelocityXHash;

    int isJumpingHash;
    int isSlashingHash;
    int isBlockingHash;
    bool slashing = false;

    void Start() {
        //search the gameobject this script is attached to and get the animator component 
        animator = GetComponent<Animator>();

        player = GetComponent<Transform>();

        weaponController = GetComponentInChildren<WeaponController>();

        // increase performance
        VelocityZHash = Animator.StringToHash("Velocity Z");
        VelocityXHash = Animator.StringToHash("Velocity X");

        isJumpingHash = Animator.StringToHash("Jump");
        isSlashingHash = Animator.StringToHash("Slash");
        isBlockingHash = Animator.StringToHash("Block");



    }


    //handles acceleretion and deceleration
    void changeVelocity(bool forwardPressed, bool leftPressed, bool rightPressed, bool backwardPressed, bool runPressed, float currentMaxVelocity) {





        // if player presses forward, increase velocity in z direction
        if (forwardPressed && velocityZ < currentMaxVelocity) {
            velocityZ += Time.deltaTime * acceleration;

        }

        // if player presses backward, increase velocity in -z direction
        if (backwardPressed && velocityZ > -currentMaxVelocity) {
            velocityZ -= Time.deltaTime * acceleration;

        }

        // increase velocity in left direction
        if (leftPressed && velocityX > -currentMaxVelocity) {
            velocityX -= Time.deltaTime * acceleration;

        }

        // increase velocity in right direction
        if (rightPressed && velocityX < currentMaxVelocity) {
            velocityX += Time.deltaTime * acceleration;

        }

        // decrease velocityZ 
        if (!forwardPressed && velocityZ > 0.0f) {
            velocityZ -= Time.deltaTime * decceleration;

        }

        // decrease velocity-Z 
        if (!backwardPressed && velocityZ < 0.0f) {
            velocityZ += Time.deltaTime * decceleration;

        }


        // increase velocityX if left is not pressed and velocityX < 0
        if (!leftPressed && velocityX < 0.0f) {
            velocityX += Time.deltaTime * decceleration;

        }

        // decrese velocityX if right is not pressed and velocityX > 0
        if (!rightPressed && velocityX > 0.0f) {
            velocityX -= Time.deltaTime * decceleration;

        }

    }

    void lockOrResetVelocity(bool forwardPressed, bool leftPressed, bool rightPressed, bool backwardPressed, bool runPressed, float currentMaxVelocity) {

        // reset velocityZ 
        if (!forwardPressed && !backwardPressed && velocityZ != 0.0f && (velocityZ > -0.05f && velocityZ < 0.05f)) {
            velocityZ = 0.0f;
        }


        //reset velocityX
        if (!leftPressed && !rightPressed && velocityX != 0.0f && (velocityX > -0.05f && velocityX < 0.05f)) {
            velocityX = 0.0f;
        }

        //locking forward
        if (forwardPressed && runPressed && velocityZ > currentMaxVelocity) {
            velocityZ = currentMaxVelocity;
        }

        //decelerate to the maximum walk velocity i
        else if (forwardPressed && velocityZ > currentMaxVelocity) {
            velocityZ -= Time.deltaTime * decceleration;
            //round to the currentMaxVelocity if within offset
            if (velocityZ > currentMaxVelocity && velocityZ < (currentMaxVelocity + 0.05f)) {
                velocityZ = currentMaxVelocity;
            }
        }
        //round to the currentMaxVelocity if within offset
        else if (forwardPressed && velocityZ < currentMaxVelocity && velocityZ > (currentMaxVelocity - 0.05f)) {
            velocityZ = currentMaxVelocity;
        }


        //SEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE
        //locking backward
        if (backwardPressed && runPressed && velocityZ < -currentMaxVelocity) {
            velocityZ = -currentMaxVelocity;
        }

        //decelerate to the maximum walk velocity i
        else if (backwardPressed && velocityZ < -currentMaxVelocity) {
            velocityZ += Time.deltaTime * decceleration;
            //round to the currentMaxVelocity if within offset
            if (velocityZ < currentMaxVelocity && velocityZ > (-currentMaxVelocity - 0.05f)) {
                velocityZ = -currentMaxVelocity;
            }
        }
        //round to the currentMaxVelocity if within offset
        else if (backwardPressed && velocityZ > -currentMaxVelocity && velocityZ < (-currentMaxVelocity + 0.05f)) {
            velocityZ = -currentMaxVelocity;
        }





        //locking right
        if (rightPressed && runPressed && velocityX > currentMaxVelocity) {
            velocityX = currentMaxVelocity;
        }

        //decelerate to the maximum walk velocity i
        else if (rightPressed && velocityX > currentMaxVelocity) {
            velocityX -= Time.deltaTime * decceleration;
            //round to the currentMaxVelocity if within offset
            if (velocityX > currentMaxVelocity && velocityX < (currentMaxVelocity + 0.05f)) {
                velocityX = currentMaxVelocity;
            }
        }
        //round to the currentMaxVelocity if within offset
        else if (rightPressed && velocityX < currentMaxVelocity && velocityX > (currentMaxVelocity - 0.05f)) {
            velocityX = currentMaxVelocity;
        }


        //locking left
        if (leftPressed && runPressed && velocityX < -currentMaxVelocity) {
            velocityX = -currentMaxVelocity;
        }

        //decelerate to the maximum walk velocity i
        else if (leftPressed && velocityX < -currentMaxVelocity) {
            velocityX += Time.deltaTime * decceleration;
            //round to the currentMaxVelocity if within offset
            if (velocityX < -currentMaxVelocity && velocityX > (-currentMaxVelocity - 0.05f)) {
                velocityX = -currentMaxVelocity;
            }
        }
        //round to the currentMaxVelocity if within offset
        else if (leftPressed && velocityX > -currentMaxVelocity && velocityX < (-currentMaxVelocity + 0.05f)) {
            velocityX = -currentMaxVelocity;
        }



    }

    // Update is called once per frame
    void Update() {

        bool forwardPressed = Input.GetKey(KeyCode.W);
        bool leftPressed = Input.GetKey(KeyCode.A);
        bool rightPressed = Input.GetKey(KeyCode.D);
        bool backwardPressed = Input.GetKey(KeyCode.S);
        bool runPressed = Input.GetKey(KeyCode.LeftShift);

        //fighting and slashing
        bool jumping = animator.GetBool("Jump");
        //bool slashing = animator.GetBool("Slash");
        //bool blocking = animator.GetBool("Block");


        bool spacebarPressed = Input.GetKey(KeyCode.Space);
        bool rightMouse = Input.GetKey(KeyCode.Mouse0);
        bool leftMouseDown = Input.GetKey(KeyCode.Mouse1);






        float gravity = 0.05f;
        if (player.position.y >= 0.01f) {
            player.position = new Vector3(player.position.x, (player.position.y - gravity) * Time.deltaTime, player.position.z);
            if (player.position.y - gravity < 0.0f) {
                player.position = new Vector3(player.position.x, (player.position.y - gravity) * Time.deltaTime, player.position.z);

            }
        }

        if (!jumping && spacebarPressed) {

            animator.SetBool(isJumpingHash, true);

        }
        if (jumping && !spacebarPressed) {

            animator.SetBool(isJumpingHash, false);
        }

        if (rightMouse && !forwardPressed) {
            if (!slashing) {
                swingSword.Play();
                animator.SetLayerWeight(2, 0.0f);
                animator.SetBool(isSlashingHash, true);
                slashing = true;
                StartCoroutine(ResetAttackCD());
            }
        }

        if (rightMouse && forwardPressed) {
            if (!slashing) {
                swingSword.Play();
                animator.SetBool(isSlashingHash, false);
                animator.SetLayerWeight(2, 1.0f);
                slashing = true;
                StartCoroutine(ResetAttackCD());
            }
        }

        if (leftMouseDown && !forwardPressed) {
            animator.SetLayerWeight(1, 0.0f);
            animator.SetBool(isBlockingHash, true);
        }

        if (leftMouseDown && forwardPressed) {
            animator.SetLayerWeight(1, 1.0f);
            animator.SetBool(isBlockingHash, false);
        }

        if (!leftMouseDown) {
            animator.SetLayerWeight(1, 0.0f);
            animator.SetBool(isBlockingHash, false);
        }

        IEnumerator ResetAttackCD() {
            yield return new WaitForSeconds(weaponController.AttackCD);
            animator.SetLayerWeight(2, 0.0f);
            animator.SetBool(isSlashingHash, false);
            slashing = false;

        }


        //set current maxVelocity
        float currentMaxVelocity = runPressed ? maximumRunVelocity : maximumWalkVelocity;


        // handle changes in velocity
        changeVelocity(forwardPressed, leftPressed, rightPressed, backwardPressed, runPressed, currentMaxVelocity);
        lockOrResetVelocity(forwardPressed, leftPressed, rightPressed, backwardPressed, runPressed, currentMaxVelocity);


        // set the parametres to our local variable values
        animator.SetFloat(VelocityZHash, velocityZ);
        animator.SetFloat(VelocityXHash, velocityX);
    }
}