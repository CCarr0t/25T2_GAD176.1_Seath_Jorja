using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutDown : MonoBehaviour
{
    //The location on the table to place the weapon
    public Transform tableSurface;
    //To check if the player is nearby
    public bool isPlayerNearby = false;
    //The weapon the player is holding
    public GameObject heldWeapon;


    void Update()
    {
        //Check if the player is nearby and presses 'Q'
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.Q))
        {
            //Make sure the player is holding the weapon
            if (heldWeapon != null)
            {
                //Place weapon on table
                heldWeapon.transform.SetParent(null); //Detach from player
                heldWeapon.transform.position = tableSurface.position; //Set position to table spawn zone
                heldWeapon.transform.rotation = tableSurface.rotation; //Set rotation to table spawn zone

                //Changes the weapon to not held
                heldWeapon.GetComponent<PickUp>().isHeld = false;
                heldWeapon = null; //Reset the held weapon to null
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Press 'Q' to drop the weapon"); // To test whether it is working
            isPlayerNearby = true;

            //Check if the player is holding a weapon
            PickUp weaponScript = other.GetComponentInChildren<PickUp>();
            if (weaponScript != null && weaponScript.isHeld)
            {
                //Set the held weapon reference
                heldWeapon = weaponScript.gameObject;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //When the player exits the table area, set nearby to flase and held weapon to null
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
            heldWeapon = null;
        }
    }
}
