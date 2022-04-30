using System.Collections;
using UnityEngine;
using System;

public class AlienWithSwordCombat : MonoBehaviour {

    public float damage;
    public bool CanAttack = true;
    public float AttackCD;
    public bool IsAttacking = false;
    Animator anim;

    WeaponController weaponController;

    public void Start() {
        anim = GetComponent<Animator>();
        weaponController = GameObject.Find("PlayerKnight/Hips/Spine/Spine1/Spine2/RightShoulder/RightArm/RightForeArm/RightHand/Sword_joint").GetComponent<WeaponController>();
    }

    private void OnTriggerStay(Collider other) {

        if (other.tag == "Player" && CanAttack) {
            Attack();
        }

        if (other.tag == "Shield" && !weaponController.IsBlocking && CanAttack) {
            Attack();
        }

         if (other.tag == "Shield" && weaponController.IsBlocking && CanAttack) {

            AttackBlocked();

         }

    }


    private void OnTriggerExit(Collider other) {
    }


    public void Attack() {
            anim.SetLayerWeight(1, 1.0f);
           // anim.SetTrigger("atk0");
            IsAttacking = true;
            CanAttack = false;
            PlayerStats player = GameObject.Find("PlayerKnight").GetComponent<PlayerStats>();
            player.currentHealth = player.currentHealth - damage;
            StartCoroutine(ResetAttackCD());
        }

    public void AttackBlocked() {
        anim.SetLayerWeight(1, 1.0f);
        //anim.SetTrigger("atk0");
        IsAttacking = true;
        CanAttack = false;
        StartCoroutine(ResetAttackCD());
    }

    IEnumerator ResetAttackCD() {
            yield return new WaitForSeconds(AttackCD);
            CanAttack = true;
            IsAttacking = false;
            anim.SetLayerWeight(1, 0.0f);
    }

}
