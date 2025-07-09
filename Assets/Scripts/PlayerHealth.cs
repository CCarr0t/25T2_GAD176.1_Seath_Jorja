using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public int maxHealth = 50;


    private void Start()
    {
        health = maxHealth;
    }


    public void TakeDamage(int amount)
    {
        health -= amount;

        if (health <= 0)
        {
            Destroy(gameObject);
            Debug.Log("Oh no! You have been killed!");
        }
    }
}
