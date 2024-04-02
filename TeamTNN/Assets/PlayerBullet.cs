using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerBullet : MonoBehaviour

{
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("destory bullet");
        Destroy(gameObject);
    }
}
