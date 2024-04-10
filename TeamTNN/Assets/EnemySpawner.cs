using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    private int enemyCount;
    private int waveNumber = 1;
 
    public float timeBetweenEnemySpawn;
    public float timeBetweenWaves;
 
    public Transform[] spawnPoints;
 
    bool spawningWave;
 
 
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemyWave(waveNumber));
        
    }
 
    // Update is called once per frame
    void Update()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("enemy").Length;
 
        if (!spawningWave)
        {
            waveNumber++;
            StartCoroutine(SpawnEnemyWave(waveNumber));
        }
    }
 
    IEnumerator SpawnEnemyWave(int enemiesToSpawn)
    {
        spawningWave = true;
        yield return new WaitForSeconds(timeBetweenWaves); //We wait here to pause between wave spawning
        Instantiate(enemyPrefab, spawnPoints[Random.Range(0, spawnPoints.Length)].position, enemyPrefab.transform.rotation);
        yield return new WaitForSeconds(timeBetweenEnemySpawn); //We wait here to give a bit of time between each enemy spawn
        
        spawningWave = false;
    }
}
