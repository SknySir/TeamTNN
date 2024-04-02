using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed;
    public Rigidbody2D rb;
    private Vector2 movement;
    public bool shooting;
    public bool punchReady;
    public GameObject fist;

    private void Start()
    {
        moveSpeed = 10f;
        shooting = false;
        punchReady = true;
    }

    // Update is called once per frame
    void Update()
    {

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            shooting = true;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            shooting = false;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Punch();
        }

    }

    private void FixedUpdate()
    {
        //also used for movement
        if (shooting == false)
        {
            rb.MovePosition(rb.position + movement * (moveSpeed * Time.fixedDeltaTime)); 
        }
        else
        {
            transform.Rotate(0.0f, 0.0f, -Input.GetAxis("Horizontal") * (moveSpeed * 2)); 
        }
    }

    void Punch()
    {
        if (punchReady == true)
        {
            GameObject punchFist = Instantiate(fist, transform.position, transform.rotation);
            Rigidbody2D rb = punchFist.GetComponent<Rigidbody2D>();
            rb.AddForce(punchFist.transform.up * 10, ForceMode2D.Impulse);
            StartCoroutine(PunchCooldown());
            punchReady = false;
        }
    }
    
    IEnumerator PunchCooldown()
    {
        yield return new WaitForSeconds(4);
        punchReady = true;
    }
    
}
