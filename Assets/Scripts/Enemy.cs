using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health;

    private void Update()
    {
            //  If the enemy's health gets to 0, the enemy gameobject is destroyed
            //  and the console tells the player they have killed an enemy

        if (health <= 0)
            Destroy(gameObject);

        if (health <= 0)
            Debug.Log("The player has killed an enemy!");
    }

}
