using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="New Gun", menuName="Guns/Gun")]
public class Gun : ScriptableObject
{
   public string gunName;
   public GameObject gunPrefab;
   
   [Header("Stats")]
   public AmmunitionTypes ammunitionType;
   public int minimumDamage;
   public int maximumDamage;
   public float maximumRange;
   
   public virtual void OnRightMouseDown()
   {

   }
  public virtual void OnMouseDown(Transform cameraPos)
   {
       
   }

   public virtual void OnMouseHold(Transform cameraPos)
   {

   }

   protected void Fire(Transform cameraPos)
   {
     if(AmmunitionManager.instance.ConsumeAmmo(ammunitionType)) //if player has ammo then shoot
      {
         RaycastHit whatIHit;
         if ( Physics.Raycast(cameraPos.position, cameraPos.transform.forward, out whatIHit, Mathf.Infinity))
         {
            Debug.Log(whatIHit.collider.name);
            IDamagable damagable= whatIHit.collider.GetComponent<IDamagable>();
            if(damagable != null)
            {
                //checks the distance of the fired shot
               float normalisedDistance = whatIHit.distance / maximumRange;
               //if the distance is more than 1 that means that it is above the max range
               if(normalisedDistance<=1)
               {
                  //make damage drop off as range goes up
                  damagable.DealDamage(Mathf.RoundToInt(Mathf.Lerp(maximumDamage,minimumDamage,normalisedDistance)));
               }
            }
         }
     }
   }
}
