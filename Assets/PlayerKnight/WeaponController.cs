using System.Collections;
using UnityEngine;

public class WeaponController : MonoBehaviour {

    public GameObject Paladin_J_Nordstrom_Sword;

    public bool CanAttack = true;
    public float AttackCD = 1.0f;
    public bool IsAttacking = false;

    private void Update() {

        if (Input.GetMouseButtonDown(0)) {
            if (CanAttack) {
                Attack();
            }
        }
    }

    public void Attack() {
        IsAttacking = true;
        CanAttack = false;
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
