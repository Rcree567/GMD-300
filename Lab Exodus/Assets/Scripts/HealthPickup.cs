
using UnityEngine;


public class HealthPickup : MonoBehaviour
{
    PlayerHealth playerHealth;

    public float healthBonus = 1f;

    void Awake()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(playerHealth.health < playerHealth.maxHealth)
        {
            Destroy(gameObject);
            playerHealth.health = playerHealth.health + healthBonus;
        }
    }
}
