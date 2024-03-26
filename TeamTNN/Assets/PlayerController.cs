using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed;
    public Rigidbody2D rb;
    private Vector2 movement;
    public bool shooting;

    private void Start()
    {
        moveSpeed = 3.5f;
        shooting = false;
    }

    // Update is called once per frame
    void Update()
    {

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            shooting = true;
        }

        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            shooting = false;
        }
        
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
        if (shooting == false)
        {
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime); 
        }
        else
        {
            transform.Rotate(0.0f, 0.0f, -Input.GetAxis("Horizontal") * moveSpeed); 
        }
    }
}
