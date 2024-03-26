using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public GameObject player;
    public float distance;
    public Vector2 cameraMove;
    
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 curPos = new Vector2(transform.position.x, transform.position.y);
        Vector2 playerPosition = new Vector2(player.transform.position.x, player.transform.position.y);
        distance = Vector2.Distance(curPos, playerPosition);
        Vector2 direction = playerPosition - curPos;
        transform.position = Vector2.MoveTowards(curPos, playerPosition, Time.deltaTime);
        cameraMove = curPos - playerPosition;

        transform.position = new Vector3(playerPosition.x, playerPosition.y, -10);
    }
}
