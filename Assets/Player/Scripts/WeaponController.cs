using System.Collections;
using UnityEngine;

public class WeaponController : MonoBehaviour {

    public GameObject Paladin_J_Nordstrom_Sword;

    public bool CanAttack = true;
    public float AttackCD = 1.2f;
    public bool IsAttacking = false;
    public bool IsBlocking = false;
    public float WeaponDamage;

    private void Update() {

        if (Input.GetMouseButtonDown(0)) {
            if (CanAttack) {
                Attack();
            }
        }

        if (Input.GetMouseButtonDown(1)) {
            if (!IsAttacking) {
                Block();
            }
        }

        if (Input.GetMouseButtonUp(1)) {
            IsAttacking = false;
            CanAttack = true;
            IsBlocking = false;
        }

    }

    public void Attack() {
        IsAttacking = true;
        CanAttack = false;
        StartCoroutine(ResetAttackCD());
    }

    public void Block() {
        IsAttacking = false;
        CanAttack = false;
        IsBlocking = true;
    }

    IEnumerator ResetAttackCD() {
        yield return new WaitForSeconds(AttackCD);
        CanAttack = true;
        IsAttacking = false;
    }

}
