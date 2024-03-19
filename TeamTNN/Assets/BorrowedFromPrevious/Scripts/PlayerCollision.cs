using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public int playerHp;
    

    private void Start()
    {
        playerHp = 5;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "enemybullet")
        {
            playerHp -= 1;
            GameObject[] gos = GameObject.FindGameObjectsWithTag("enemybullet");
            foreach (var go in gos)
            {
                Destroy(go);
            }
        }
    }
}
