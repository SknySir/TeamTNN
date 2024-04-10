using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
        if (health < 0)
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "enemybullet")
        {
            health -= 1;
            HealthBar.value = health;
        }
    }
}
