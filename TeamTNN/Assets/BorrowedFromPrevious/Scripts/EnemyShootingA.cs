using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class EnemyShootingA : MonoBehaviour
{

    public GameObject bulletPrefab;
    public GameObject player;
    public float shotDelay;
    public float bulletForce;
    public Vector3 newVector;
    public float distance;
    public float speed;
    public Vector2 chaserMove;


    private void Start()
    {
        speed = 0.5f;
        bulletForce = 300f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float curPosY = transform.position.y;
        newVector = (player.transform.position - this.transform.position).normalized;
        ShootingAction();
        
        
        var playerPosition = player.transform.position;
        distance = Vector2.Distance(this.transform.position, playerPosition);
        Vector2 direction = playerPosition - transform.position;
        transform.position = Vector2.MoveTowards(this.transform.position, playerPosition, speed * Time.deltaTime);
        chaserMove = transform.position - playerPosition;
        
    }


    void ShootingAction()
    {
        if (shotDelay >= 100)
        {
            StartCoroutine(ShootingCoroutine());
            shotDelay = 0;
        }

        else
        {
            shotDelay += 1;
        }
    }

    void Shoot()
    {
        Debug.Log("startshootfunc");
        //aSide = this.transform.position.y - player.transform.position.y;
        //bSide = this.transform.position.x - player.transform.position.x;
        // cSide = (math.sqrt(aSide * aSide) + (bSide * bSide));
        //firingAngle = ((aSide / cSide));
        
        //Debug.Log(firingAngle);
        
      
        Debug.LogFormat("Enemy: {0}, Player {1}, New Vector {2}", transform.position, player.transform.position, newVector);
        
        
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation );
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(newVector * bulletForce, ForceMode2D.Force);
    }

    IEnumerator ShootingCoroutine()
    {
        Shoot();
        yield return new WaitForSeconds((float).1);
        Shoot();
        yield return new WaitForSeconds((float).1);
        Shoot();
        
    }
}
