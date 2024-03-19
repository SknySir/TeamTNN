using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed;
    public Rigidbody2D rb;
    private Vector2 movement;

    private void Start()
    {
        moveSpeed = 3.5f;
    }

    // Update is called once per frame
    void Update()
    {
        //movement, no anims
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        
        // focus controls

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            moveSpeed = 1.5f;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            moveSpeed = 3f;
        }
        
        //cursed relic, do not touch or else the spirits may be angry
        
        
    }

    private void FixedUpdate()
    {
        //also used for movement
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime); 
    }
}
