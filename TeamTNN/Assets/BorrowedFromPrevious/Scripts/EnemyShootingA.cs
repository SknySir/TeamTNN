using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Animations;

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
    public List<GameObject> moveNodeList = new List<GameObject>();
    public float playerDisX;
    public float playerDisY;
    public bool aggro;
    public int moveListPlacement;
    public GameObject curPoint;
    public Rigidbody2D rb;


    private void Start()
    {
        player = GameObject.Find("Player");
        speed = 10f;
        bulletForce = 300f;
        foreach (GameObject node in GameObject.FindGameObjectsWithTag("node"))
        {
            moveNodeList.Add(node);
        }
        moveNodeList.Sort((a,b) => a.name.CompareTo(b.name));
        aggro = false;
        moveListPlacement = moveNodeList.Count-1;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float curPosY = transform.position.y;
        newVector = (player.transform.position - this.transform.position).normalized;
        

        playerDisX = Math.Abs(player.transform.position.x - this.transform.position.x);
        playerDisY = Math.Abs(player.transform.position.y - this.transform.position.y);
        
        curPoint = moveNodeList[moveListPlacement];

        if (playerDisX < 5 && playerDisY < 5)
        {
            aggro = true;
        }

        if (aggro == true)
        {
            AggroMove();
            //AimConstraint.WorldUpType.ObjectRotationUp
            //float angle = Mathf.Atan2(player.transform.position.x, player.transform.position.y) * Mathf.Rad2Deg -90;
            //float xDiff = this.transform.rotation.x - player.transform.rotation.x;
            //float yDiff = this.transform.rotation.y - player.transform.rotation.y;
            //float angleA = Mathf.Atan2(yDiff, xDiff) Mathf.Rad2Deg;
            //float angleB = Mathf.Atan2(yDiff, xDiff) Mathf.Rad2Deg;
            transform.up = player.transform.position - this.transform.position;
            ShootingAction();
        }
        else
        {
            NonAggroMove();
        }


        
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
        
      
        //Debug.LogFormat("Enemy: {0}, Player {1}, New Vector {2}", transform.position, player.transform.position, newVector);
        
        
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation );
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(newVector * (bulletForce), ForceMode2D.Force);
    }

    IEnumerator ShootingCoroutine()
    {
        Shoot();
        yield return new WaitForSeconds((float).1);
        Shoot();
        yield return new WaitForSeconds((float).1);
        Shoot();
        
    }

    void AggroMove()
    {
       
        rb.MovePosition(Vector2.MoveTowards(this.transform.position, player.transform.position, (speed/3) * Time.deltaTime));
    }

    void NonAggroMove()
    {
        var position = this.transform.position;
        float testX = (math.abs(curPoint.transform.position.x) - (math.abs(this.transform.position.x)));
        float testY = (math.abs(curPoint.transform.position.y) - (math.abs(this.transform.position.y)));
        Debug.LogFormat("DifX: {0}, DifY {1}, Point {2}", testX, testY, moveListPlacement);
        
        if (this.transform.position != curPoint.transform.position)
        {
            rb.MovePosition(Vector2.MoveTowards(this.transform.position, curPoint.transform.position, speed * Time.deltaTime));
        }
        if (testX == 0 & testY == 0)
        {
            moveListPlacement -= 1;
            
            
            if (moveListPlacement < 0)
            {
                moveListPlacement = moveNodeList.Count-1;
            }
        }

    }
}
