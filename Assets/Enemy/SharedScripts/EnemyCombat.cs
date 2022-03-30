using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour {

    [SerializeField] float damage;
    public bool CanAttack = true;
    public float AttackCD = 1.0f;
    public bool IsAttacking = false; 

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player" && CanAttack) {
            Attack();

        }
    }

        public void Attack() {
            IsAttacking = true;
            CanAttack = false;
        PlayerStats player = GameObject.Find("PlayerKnight").GetComponent<PlayerStats>();
        player.currentHealth = player.currentHealth - damage;
            StartCoroutine(ResetAttackCD());
        }

        IEnumerator ResetAttackCD() {
            StartCoroutine(ResetAttack());
            yield return new WaitForSeconds(AttackCD);
            CanAttack = true;
        }

        IEnumerator ResetAttack() {
            yield return new WaitForSeconds(1.7f);
            IsAttacking = false;
        }

    }
