using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Allows the enemy to follow/chase the player
/// </summary>
public class MeleeEnemy : Enemy
{
    [Header("Core Properties")]
    [SerializeField] private Rigidbody enemy;

    [Header("AI Functionality")]
    [SerializeField] private GameObject chaseTarget;
    [SerializeField] private bool isCurrentlyChasing;

    public int damage = 15;
    public PlayerHealth playerHealth;

    private void Update()
    {
        if (chaseTarget == null)
        {
            Destroy(gameObject);
        }
    }

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
