using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [Header("Bullet Variables")]
    public float bulletSpeed;
    public float fireRate, bulletDamage;
    public bool isAuto;

    [Header("Initial Setup")]
    public Transform bulletSpawnTransform;
    public GameObject bulletPrefab;

    private float timer;

    private void Update()
    {

        // How many bullets the gun can shoot at a time (fire rate)

        if (timer > 0)
            timer -= Time.deltaTime / fireRate;

        // If the player presses the mouse button once, the gun shoots once
        // If the player holds the mouse button, the gun sprays bullets

        if (isAuto)
        {
            if (Input.GetButton("Fire1") && timer <= 0)
            {
                Shoot();
            }
        }
        else
        {
            if (Input.GetButtonDown("Fire1") && timer <= 0)
            {
                Shoot();
            }
        }
    }

    // Shooting out the bullet/the bullet prefab

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnTransform.position, Quaternion.identity, GameObject.FindGameObjectWithTag("WorldObjectHolder").transform);

        // The force behind the bullet to actually have it shoot out of the gun

        bullet.GetComponent<Rigidbody>().AddForce(bulletSpawnTransform.forward * bulletSpeed, ForceMode.Impulse);
        bullet.GetComponent<Bullet>().damage = bulletDamage;

        timer = 1;
    }
}
