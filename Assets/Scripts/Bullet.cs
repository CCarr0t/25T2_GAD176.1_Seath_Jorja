using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage;
    public float lifeTime = 3;

    private void Update()
    {
            // How long the bullet is in the world for. The bullet is destroyed after a certain amount of time

        lifeTime -= Time.deltaTime;

        if (lifeTime < 0)
            Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
            // When the bullet collides with an enemy, the enemy is destroyed/damaged

        if (other.GetComponent<Enemy>() != null)
            other.GetComponent<Enemy>().health -= damage;

        Destroy(gameObject);
    }
}
