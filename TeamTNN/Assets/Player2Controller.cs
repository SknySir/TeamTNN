using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Controller : MonoBehaviour
{
    public float moveSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 1.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey ("left")) {
            transform.Rotate(0, 0, 1f);
        }
        if (Input.GetKey ("right")) {
            transform.Rotate(0, 0, -1f);
        }
    }
}
