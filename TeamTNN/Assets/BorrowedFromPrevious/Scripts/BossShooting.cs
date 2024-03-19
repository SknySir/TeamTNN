using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShooting : MonoBehaviour
{
    
    public float moveLine;
    public float moveSpeed;
    public float shotDelay;
    private float bulletForce;
    public GameObject bulletPrefab1;
    public GameObject bulletPrefab2;
    public GameObject bulletPrefab3;
    public string test = "✄";
    public int arrayVectorPlacment;
    public GameObject player;
    public Vector3 newVector;
    private int shotTimer;
    private int shotState;
    private int shotCharge;
    private int fireSpeed;
    private int fireSpeedCounter;
    public bool rotateClockPos;
    public bool shotDirectionBool;
    public float rotationSpeed;
    public EnemyHealth hp;
    public Transform firePoint;
    public GameObject firePointObject;
    private Vector3 currentFireDirection;
    private int curHp;
    public Rigidbody2D rb;
    private Vector2[] shotVector =
    {
        new Vector2(0,-1), new Vector2(1,-1), new Vector2(1,0), new Vector2(1,1)
        , new Vector2(0,1), new Vector2(-1,1), new Vector2(-1,0), new Vector2(-1,-1)
    };

    private void Start()
    {
        shotTimer = 0;
        shotState = 0;
        shotCharge = 0;
        bulletForce = 0;
        fireSpeed = 0;
        rotationSpeed = 0;
        shotDirectionBool = true;
        currentFireDirection = Vector3.left;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float curPosY = transform.position.y;
        newVector = (player.transform.position - this.transform.position).normalized;
        curHp = this.GetComponent<EnemyHealth>().enemyHp;

        if (curHp <= 500)
        {
            shotState = 1;
        }

        if (curPosY >= moveLine - 0.5) 
        {
            transform.Translate(Vector3.down * Time.deltaTime * moveSpeed);
        }
        
        if (curPosY <= moveLine ) 
        {
            if (shotState == 0)
            {
                shotTimer = 5;
                bulletForce = 50;
                
                if (shotDelay >= shotTimer)
                {
                    Shoot1();
                    shotDelay = fireSpeed;
                    shotCharge += 1;
                }

                else
                {

                    shotDelay += 1;
                }

                if (shotCharge == 8)
                {
                    Shoot2();
                    fireSpeedCounter += 1;
                    shotCharge = 0;
                }

                if (fireSpeedCounter == 20)
                {
                    fireSpeed += 1;
                    fireSpeedCounter = 0;
                }

            }

            if (shotState == 1)
            {
                shotTimer = 2;
                bulletForce = 50;
                
                if (rotateClockPos == true)
                {
                    transform.Rotate(0,0, rotationSpeed);
                    rotationSpeed += 0.1f;
                }
                if (rotateClockPos != true)
                {
                   transform.Rotate(0,0, rotationSpeed);
                    rotationSpeed -= 0.1f;
                }

                if (rotationSpeed > 20)
                {
                    rotateClockPos = false;
                    
                }
                
                if (rotationSpeed < -20)
                {
                    rotateClockPos = true;
                    
                }
                
                if (shotDelay >= shotTimer)
                {
                    Shoot4();
                    shotDelay = fireSpeed;
                    shotCharge += 1;
                }

                else
                {

                    shotDelay += 1;
                }

                if (shotCharge == 8)
                {
                    Shoot3();
                    fireSpeedCounter += 1;
                    shotCharge = 0;
                    
                    if (shotDirectionBool == true)
                    {
                        currentFireDirection = Vector3.left;
                        shotDirectionBool = false;
                    }

                    if (shotDirectionBool != true)
                    {
                        currentFireDirection = Vector3.right;
                        shotDirectionBool = true;
                    }
                }

                if (fireSpeedCounter == 20)
                {
                    fireSpeed += 1;
                    fireSpeedCounter = 0;
                }
                
            }
        }
        
    }
    

    void Shoot1()
    {
        Debug.Log(shotVector.Length);
        
        Vector2 bulletVector = shotVector[arrayVectorPlacment];
        GameObject bullet = Instantiate(bulletPrefab2, transform.position, transform.rotation );
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
    
    void Shoot2()
    {
        Debug.Log("startshootfunc");
        
      
        Debug.LogFormat("Enemy: {0}, Player {1}, New Vector {2}", transform.position, player.transform.position, newVector);
        
        
        GameObject bullet1 = Instantiate(bulletPrefab1, transform.position, transform.rotation );
        Rigidbody2D rb = bullet1.GetComponent<Rigidbody2D>();
        rb.AddForce(newVector * bulletForce, ForceMode2D.Force);
    }

    void Shoot3()
    {
        
        
        float forceRange = UnityEngine.Random.Range(50, -50);

        GameObject bullet3 = Instantiate(bulletPrefab3, transform.position, transform.rotation );
        Rigidbody2D rb = bullet3.GetComponent<Rigidbody2D>();
        rb.AddForce(currentFireDirection * forceRange, ForceMode2D.Force);
        
    }

    void Shoot4()
    {
        Vector3 tempVec = gameObject.transform.position;
        
        GameObject bullet2 = Instantiate(bulletPrefab2, transform.position, transform.rotation );
        Rigidbody2D rb = bullet2.GetComponent<Rigidbody2D>();
        rb.AddForce(bullet2.transform.up * bulletForce, ForceMode2D.Force);
    }
}
