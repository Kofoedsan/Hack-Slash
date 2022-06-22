using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.UI;



public class PoolingEnemy : MonoBehaviour {

    [SerializeField] private GameObject enemy;

    [SerializeField] List<GameObject> enemyList = new List<GameObject>();

    [SerializeField] private GameObject hpCrystal0;

    [SerializeField] private GameObject hpCrystal1;

    [SerializeField] private Transform player;

    private Text score;

    public GameObject spawnedEnemy;

    private GameObject spawnedCrystal;

    System.Random r = new System.Random();

    private float spawnCd = 5.0f;

    private bool spawnRecently = false;

    private int points = 0;

    private int bonuslevel = 5;

    private float dmgbuff = 1.0f;

    // private float hpbuff = 1.0f;

    private bool bonusSpawn = false;


    void Start() {

        for (int i = 0; i < enemyList.Capacity; i++) {
            enemyList[i].GetComponent<EnemyMovement>().Player = player;
        }


        int rInt = r.Next(0, 2);
        score = GameObject.Find("Score").GetComponent<Text>();
        spawnedEnemy = Instantiate(enemyList[rInt], new Vector3(98, 0, 61), Quaternion.identity) as GameObject;
    }

    private void Update() {
     
        if (points == bonuslevel) {
            if (points == bonuslevel && !bonusSpawn) {

                int rInt = r.Next(0, 2);
                if (rInt == 0) {
                    spawnedCrystal = Instantiate(hpCrystal0, new Vector3(90, 0, 70), Quaternion.identity) as GameObject;

                } else if (rInt == 1) {
                    spawnedCrystal = Instantiate(hpCrystal1, new Vector3(90, 0, 70), Quaternion.identity) as GameObject;
                }
                bonusSpawn = true;
                bonuslevel = points +5;
                spawnCd = spawnCd - 0.5f;
            }
        } else {
            bonusSpawn = false;
        }
           

        if (spawnedEnemy.GetComponent<EnemyDeath>().isDead && !spawnRecently) {
            points++;
            score.text = points.ToString();

           
            int rInt = r.Next(0, 4);

            int enemynumber = r.Next(0, 2);


            if (rInt == 0) {
                spawnedEnemy = Instantiate(enemyList[enemynumber], new Vector3(98, 0, 61), Quaternion.identity) as GameObject;
            } else if (rInt == 1) {
                spawnedEnemy = Instantiate(enemyList[enemynumber], new Vector3(80, 0, 78), Quaternion.identity) as GameObject;
            } else if (rInt == 2) {
                spawnedEnemy = Instantiate(enemyList[enemynumber], new Vector3(80, 0, 61), Quaternion.identity) as GameObject;
            } else if (rInt == 3) {
                spawnedEnemy = Instantiate(enemyList[enemynumber], new Vector3(98, 0, 78), Quaternion.identity) as GameObject;
            }


            try {
                spawnedEnemy.GetComponent<EnemyCombat>().damage = enemyList[enemynumber].GetComponent<EnemyCombat>().damage + dmgbuff * points;
            } catch {
                spawnedEnemy.GetComponent<AlienWithSwordCombat>().damage = enemyList[enemynumber].GetComponent<AlienWithSwordCombat>().damage + dmgbuff * points;
            }
            //spawnedEnemy.transform.localScale = new Vector3(spawnedEnemy.transform.localScale.x * 1.05f, spawnedEnemy.transform.localScale.y * 1.05f, spawnedEnemy.transform.localScale.z * 1.05f);
            spawnedEnemy.GetComponent<EnemyDeath>().isDead = false;
            //spawnedEnemy.GetComponent<EnemyDeath>().health = enemy.GetComponent<EnemyDeath>().health + hpbuff*points;



            spawnRecently = true;
            StartCoroutine(SpawnCD());
        }
    }

    IEnumerator SpawnCD() {
        yield return new WaitForSeconds(spawnCd);
        spawnRecently = false;
    }
}
