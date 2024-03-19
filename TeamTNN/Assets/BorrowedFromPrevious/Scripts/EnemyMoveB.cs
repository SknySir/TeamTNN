using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vector2 = System.Numerics.Vector2;

public class EnemyMoveB : MonoBehaviour
{

    public float rotateRange;
    public float moveSpeed;
    public float shotDelay;
    public float bulletForce;
    public float moveLine;
    public GameObject bulletPrefab;
    
    
    // Start is called before the first frame update
    void Start()
    {
        float range = Random.Range(rotateRange, -rotateRange);
        var transformRotation = transform.rotation;
        transformRotation.z = range;
        transform.rotation = transformRotation;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        transform.Translate(UnityEngine.Vector2.up * Time.deltaTime * moveSpeed);
        
        
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

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation );
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(UnityEngine.Vector2.down * bulletForce, ForceMode2D.Force);
    }
}
