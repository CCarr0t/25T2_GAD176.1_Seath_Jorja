using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKnifeDamage : MonoBehaviour
{
    public int damage = 15;
    public PlayerHealth playerHealth;


    private void OnCollisionEnter(Collision collision)
    {
            // When the melee enemy collides with the player, the player takes damage

        if(collision.gameObject.tag == "Player")
        {
            if(playerHealth == null)
            {
                playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            }
            playerHealth.TakeDamage(damage);
        }
    }
}
