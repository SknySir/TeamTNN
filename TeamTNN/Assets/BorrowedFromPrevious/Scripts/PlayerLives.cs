using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLives : MonoBehaviour
{
    public GameObject player;
    public GameObject hp1;
    public GameObject hp2;
    public GameObject hp3;
    public GameObject hp4;
    public GameObject hp5;

    // Update is called once per frame
    void Update()
    {
        int playerHp = player.GetComponent<PlayerCollision>().playerHp;

        if (playerHp <= 4)
        {
            hp5.SetActive(false);
        }
        
        if (playerHp <= 3)
        {
            hp4.SetActive(false);
        }
        
        if (playerHp <= 2)
        {
            hp3.SetActive(false);
        }
        
        if (playerHp <= 1)
        {
            hp2.SetActive(false);
        }
        
        if (playerHp <= 0)
        {
            SceneManager.LoadScene("OnlyScene");
        }

    }
    
    
}
