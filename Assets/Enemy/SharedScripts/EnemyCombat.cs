using System.Collections;
using UnityEngine;
using System;

public class EnemyCombat : MonoBehaviour {

    public float damage;
    public bool CanAttack = true;
    public float AttackCD;
    public bool IsAttacking = false;
    public bool colliding = false;
    Animator anim;

    WeaponController weaponController;

    public void Start() {
        anim = GetComponent<Animator>();
        weaponController = GameObject.Find("PlayerKnight/Hips/Spine/Spine1/Spine2/RightShoulder/RightArm/RightForeArm/RightHand/Sword_joint").GetComponent<WeaponController>();
    }

        private void OnTriggerEnter(Collider other) {
        colliding = true;

        // while (colliding == true) {

            if (other.tag == "Player" && CanAttack) {

                Attack();
            }

            if (other.tag == "Shield" && !weaponController.IsBlocking && CanAttack) {
                Attack();
            }

            if (other.tag == "Shield" && weaponController.IsBlocking && CanAttack) {
                StartCoroutine(ResetAttackCD());
            }
        // }
    }

    private void OnTriggerExit(Collider other) {
        colliding = false;
    }


    public void Attack() {
            System.Random r = new System.Random();
            int rInt = r.Next(0, 6);
            anim.SetTrigger("atk" + rInt);
            IsAttacking = true;
            CanAttack = false;
            PlayerStats player = GameObject.Find("PlayerKnight").GetComponent<PlayerStats>();
            player.currentHealth = player.currentHealth - damage;
            StartCoroutine(ResetAttackCD());
        }
        IEnumerator ResetAttackCD() {
            yield return new WaitForSeconds(AttackCD);
            CanAttack = true;
            IsAttacking = false;
    }

}
