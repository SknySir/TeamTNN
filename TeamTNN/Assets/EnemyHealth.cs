using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    public int enemyHp;
    public bool bossDead;

    
    private void Awake()
    {
        
            bossDead = false;
        
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        
        if (enemyHp <= 0)
        {
            bossDead = true;
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "playerbullet")
        {
            enemyHp -= 1;
        }
    }
}
