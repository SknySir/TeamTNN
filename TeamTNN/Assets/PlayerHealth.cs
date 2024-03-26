using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float health;
    public Slider HealthBar;

    // Start is called before the first frame update
    void Start()
    {
        HealthBar.value = health;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="enemybullet")
        {
            health -= 10;
            HealthBar.value = health;
        }
    }
}
