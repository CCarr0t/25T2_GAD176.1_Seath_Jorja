using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// Allows the enemy to follow/chase the player
/// </summary>
public class Enemy : MonoBehaviour
{
    [Header("Core Properties")]
    [SerializeField] private Rigidbody enemy;

    [Header("AI Functionality")]
    [SerializeField] private GameObject chaseTarget;
    [SerializeField] private bool isCurrentlyChasing;

    public float health;

    private void Update()
    {
            //  If the enemy's health gets to 0, the enemy gameobject is destroyed
            //  and the console tells the player they have killed an enemy

        if (health <= 0)
            Destroy(gameObject);

        if (health <= 0)
            Debug.Log("The player has killed an enemy!");

        if (chaseTarget == null)
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        if (isCurrentlyChasing == false)
        {
                //Enemy Movement
            if (enemy.velocity.magnitude < 5)
            {
                    //Input.GetAxis("Vertical") ...W/S
                    //Input.GetAxis("Horizontal") ...A/D
                enemy.AddForce(Input.GetAxis("Horizontal") * 5, 0, Input.GetAxis("Vertical") * 5);
            }
        }
        else
        {
                //AI chasing movement
                //We need a TARGET (the player)
                //Move enemy AI towards the target
            if (enemy.velocity.magnitude < 1)
            {
                //AI needs to know the directions from the AI itself to the player
                //target.position - me.position
                enemy.AddForce(chaseTarget.transform.position - gameObject.transform.position);
            }
        }
    }

}
