using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerBullet : MonoBehaviour

{
    
    
    private void Start()
    {
        //
        
    }


    private void OnCollisionEnter2D(Collision2D collision2D)
    { 
       
        Destroy(gameObject);
       
    }
    
}
