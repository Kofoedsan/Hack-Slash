using System.Collections;
using UnityEngine;
using System;

public class EnemyCombat : MonoBehaviour {

    public float damage;
    public bool CanAttack = true;
    public float AttackCD = 0.5f;
    public bool IsAttacking = false;
    Animator anim;


    public void Start() {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player" && CanAttack) {
            Attack();
        }
    }

        public void Attack() {

            System.Random r = new System.Random();

            int rInt = r.Next(0, 6);

            anim.SetTrigger("atk" + rInt);
            Debug.Log("ran");

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
