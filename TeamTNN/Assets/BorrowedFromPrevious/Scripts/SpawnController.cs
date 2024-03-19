using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using Random = System.Random;
using Vector3 = System.Numerics.Vector3;

public class SpawnController : MonoBehaviour
{
    public GameObject EnemyA;
    public GameObject EnemyB;
    public GameObject EnemyC;
    public GameObject EnemyD;
    public GameObject Boss;
    private GameObject[] enemyArray = {};
    public int arrayPointer;
    public int timerCount;
    public int spawnDelay;
    public GameObject playerFromSpawner;
    public int enemiesSpawned;
    public bool bossDead;
    private GameObject boss;

    private void Start()
    {
        bossDead = true;
        spawnDelay = 300;
        timerCount = 200;
        enemyArray = new[] {EnemyA, EnemyB, EnemyC, EnemyD };
        enemyArray[0] = EnemyA;
        enemyArray[1] = EnemyB;
        enemyArray[2] = EnemyC;
        enemyArray[3] = EnemyD;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        arrayPointer = UnityEngine.Random.Range(1, 4);
        

        if (bossDead == true)
        {
            if (timerCount >= spawnDelay)
            {
                Spawn();
                timerCount = 0;
                enemiesSpawned += 1;
                if (spawnDelay >= 100)
                {
                    spawnDelay -= 20;
                }
            }

            else
            {
                timerCount += 1;
            }
        }

        if (bossDead != true)
        {
            Debug.Log("Boss is Alive");
            if (boss.IsDestroyed())
            {
                bossDead = true;
            }
        }

        if (enemiesSpawned >= 10)
        {
            GameObject[] gos = GameObject.FindGameObjectsWithTag("enemy");
            foreach (var go in gos)
            {
                Destroy(go);
            }
            Debug.Log("yesboss");
            SpawnBoss();
            enemiesSpawned = 0;
            bossDead = false;
            

        }
        else
        {
            Debug.Log("noboss");
            
        }
    }
    
    

    void Spawn()
    {
        
        
        Debug.LogFormat("ArrayLength: {0}, Pointer {1}", enemyArray.Length, arrayPointer);
        float randX = UnityEngine.Random.Range(-4, 4);
        float randY = UnityEngine.Random.Range(6, 12);
        transform.position = new (randX, randY, 0);
        GameObject chosenEnemy = enemyArray[arrayPointer];
        GameObject enemy = Instantiate(chosenEnemy, transform.position, transform.rotation);
        if (arrayPointer == 2)
        {
            enemy.GetComponent<EnemyShootingA>().player = playerFromSpawner;
        }
    }

    void SpawnBoss()
    {
        UnityEngine.Vector3 bossPos = new UnityEngine.Vector3(0f, 10f, 0f);
        boss = Instantiate(Boss, bossPos, transform.rotation);
        boss.GetComponent<BossShooting>().player = playerFromSpawner;
    }
}
