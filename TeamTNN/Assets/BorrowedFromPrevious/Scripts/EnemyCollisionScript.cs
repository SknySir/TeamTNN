using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemyScript : MonoBehaviour
{

    public float moveSpeed = 0.05f;
    bool canBeDestroyed = false;
    

    

    // Update is called once per frame
    void Update()
    {

        if (transform.position.y < 4.5 && !canBeDestroyed)
        {
            canBeDestroyed = true;
        }
    }
    
 
    private void OnCollisionEnter2D(Collision2D collider)
    {
        if (!canBeDestroyed)
        {
            return;
        }

        Debug.Log("collision");
        if (collider.gameObject.tag == "wall")
        { 
            Debug.Log("Please God trust me and give me strength for I need it");
            Destroy(gameObject);
           
        }
    }
}
