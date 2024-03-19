using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootingB : MonoBehaviour
{
    public float moveLine;
    public float moveSpeed;
    public float shotDelay;
    public float bulletForce;
    public GameObject bulletPrefab;
    public string test = "✄";
    public int arrayVectorPlacment;
    private Vector2[] shotVector =
    {
        new Vector2(0,-1), new Vector2(1,-1), new Vector2(1,0), new Vector2(1,1)
        , new Vector2(0,1), new Vector2(-1,1), new Vector2(-1,0), new Vector2(-1,-1)
    };

    // Update is called once per frame
    void FixedUpdate()
    {
        float curPosY = transform.position.y;
        
        if (curPosY >= moveLine - 0.5) 
        {
            transform.Translate(Vector3.down * Time.deltaTime * moveSpeed);
        }
        
        if (curPosY <= moveLine ) 
        {
            if (shotDelay >= 10)
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
        Debug.Log(shotVector.Length);
        
        Vector2 bulletVector = shotVector[arrayVectorPlacment];
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation );
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(bulletVector * bulletForce, ForceMode2D.Force);
        
        if (arrayVectorPlacment >= shotVector.Length - 1)
        {
            arrayVectorPlacment = 0;
        }
        else
        {
            arrayVectorPlacment += 1;
        }
    }
}
