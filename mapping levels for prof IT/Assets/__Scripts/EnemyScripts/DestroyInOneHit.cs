using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyInOneHit : MonoBehaviour, IDamagable
{
    public void DealDamage(int damage)
    {
        Destroy(gameObject); //destroys the gameobject in one hit
        
    }
}
