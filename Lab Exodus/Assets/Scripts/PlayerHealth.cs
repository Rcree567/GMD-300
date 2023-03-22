using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public float health;
    public float maxHealth = 4;

    public SpriteRenderer playerSr;
    public PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
       

    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        if(health <=0)
        {
            playerSr.enabled = false;
            playerController.enabled = false;
        }
    }
    
}
