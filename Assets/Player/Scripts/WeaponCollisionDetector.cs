using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCollisionDetector : MonoBehaviour
{
    public WeaponController wp;

    private EnemyDeath enemyDeath;
  

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Enemy" && wp.IsAttacking) {
            enemyDeath = other.GetComponent<EnemyDeath>();
            enemyDeath.health = enemyDeath.health - wp.WeaponDamage;

        }

  
    }

}
