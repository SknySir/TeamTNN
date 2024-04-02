using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnScript : MonoBehaviour
{
    public bool spawnEnemies;
    public GameObject enemyPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            
    }

    IEnumerator SpawnRoutine()
    {
        Vector3 spawnPos = Vector3. zero;

        while (spawnEnemies == true)
        {
            yield return new WaitForSeconds(2f);

            spawnPos.x = this.transform.position.x;
            spawnPos.y = this.transform.position.y;
            
            Instantiate(enemyPrefab, spawnPos, Quaternion.identity);

        }
    }

}
