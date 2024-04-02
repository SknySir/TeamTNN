using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{

    //public Transform firepoint;
    public GameObject bulletPrefab;
    public float shotDelay;
    public float bulletDelay;

    

    public float bulletForce = 50f;

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey(KeyCode.LeftShift))
        {
            bulletDelay = 5;
           
        }
        else
        {
            bulletDelay = 30;
           
        }
        
        if (Input.GetKey(KeyCode.Z))
        {
            if (shotDelay >= 4)
            {
                Shoot();
                shotDelay = 0;
            }

            else
            {
                shotDelay += 1;
            }
        }
    }

    void Shoot()
    {
        //float range = Random.Range(bulletDelay, -bulletDelay);
        //float xpos = firepoint.position.x + range;
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
       //bullet.transform.Rotate((float)0, 0, (float)range);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(bullet.transform.up * 1000, ForceMode2D.Force);

    }
    
}
