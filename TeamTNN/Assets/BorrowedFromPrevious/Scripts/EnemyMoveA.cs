using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveA : MonoBehaviour
{

    public float startSpeed;
    public float moveLine;
    public float moveDelay;
    public float moveTimer = 0;

    

    // Update is called once per frame
    void FixedUpdate()
    {
        
        float curPosY = transform.position.y;

        if (curPosY >= moveLine - 0.5) 
        {
            transform.Translate(Vector3.down * Time.deltaTime * startSpeed);
        }

        if (curPosY <= moveLine)
        {
            if (moveTimer >= moveDelay)
            {
                transform.Translate(Vector3.down * Time.deltaTime * startSpeed);
            }

            else
            {
                moveTimer += 1;
                
            }
        }

    }

    private void MoveAfterDelay()
    {
        
    }


}
