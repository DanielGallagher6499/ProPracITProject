using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmunitionPickup : MonoBehaviour
{
    [SerializeField] private int AmmoCount;
    [SerializeField] private AmmunitionTypes ammunitionType;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.GetComponent<PlayerMovement>()!=null) //when we collide, check if the thing that we collide with has playermovement
        {
            	AmmunitionManager.instance.AddAmmo(AmmoCount,ammunitionType); //add ammo when we collide with the player
                Destroy(gameObject); //destroy ammo box
        }
    }
}
