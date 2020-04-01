using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHandler : MonoBehaviour
{
   [SerializeField] private List<Gun> guns= new List<Gun>();

   private Gun currentGun;
   private Transform cameraTransform;
   private GameObject currentGunPrefab;

    public Vector3 offset=new Vector3(0.5f,0.0f,0.5f);

   //public float startFireTime;
   //private float fireTime;

    /*enum weaponType
    {
        single,automatic
    }
    
    private weaponType gunType;*/

   private void Start()
   {    
       cameraTransform=Camera.main.transform;
       currentGunPrefab=Instantiate(guns[0].gunPrefab,transform);//spawns gun
       currentGun=guns[0]; // sets the current gun to the pistol
      // gunType=weaponType.automatic; //sets gun to be automatic
   }

    private void Update()
    {
        CheckForShooting();
        SwitchGuns();
    }
    private void SwitchGuns()
    {
         if(Input.GetKeyDown(KeyCode.Alpha1)) //weapon switching
        {
            Destroy(currentGunPrefab);
            currentGunPrefab=Instantiate(guns[0].gunPrefab,transform);
            
           // gunType=weaponType.automatic;
            currentGun=guns[0];
        }

        else if(Input.GetKeyDown(KeyCode.Alpha2)) 
        {
            Destroy(currentGunPrefab);
            currentGunPrefab=Instantiate(guns[1].gunPrefab,transform);
            currentGun=guns[1];
            //gunType=weaponType.single;
        }

        else if(Input.GetKeyDown(KeyCode.Alpha3)) 
        {
            Destroy(currentGunPrefab);
            currentGunPrefab=Instantiate(guns[2].gunPrefab,transform);
            
           // Instantiate(guns[3].gunPrefab,transform=new Vector3 + offset, Quaternion.identity );  
            currentGun=guns[2];
            //gunType=weaponType.single;
        }
    }
    /*private void CheckForAmmo()
    {
        if(AmmunitionManager.instance.GotAmmo())
      {
          CheckForShooting();
      }
    }*/
    private void CheckForShooting()
    {   
        if(Input.GetMouseButtonDown(0))//if gun is single fire
        {       
            currentGun.OnMouseDown(cameraTransform);
                //SingleFire();
            
        }
        else if(Input.GetMouseButton(0)) //if gun is automatic
        {   
            currentGun.OnMouseHold(cameraTransform);
               // AutoFire();
   
        }
    }

    /*private void SingleFire()
    {   
        if(ammunitionManager.ConsumeAmmo())
        {
            if(gunType==weaponType.single)
            {
                RaycastHit whatIHit;
                if(Physics.Raycast(cameraTransform.position, transform.forward, out whatIHit, Mathf.Infinity))
                {
                    Debug.Log(whatIHit.collider.name);

                    IDamagable damagable= whatIHit.collider.GetComponent<IDamagable>();
                    if(damagable!=null)
                    {
                        //checks the distance of the fired shot
                        float normalisedDistance = whatIHit.distance / currentGun.maximumRange;
                        //if the distance is more than 1 that means that it is above the max range
                        if(normalisedDistance<=1)
                        {
                            //make damage drop off as range goes up
                            damagable.DealDamage(Mathf.RoundToInt(Mathf.Lerp(currentGun.maximumDamage,currentGun.minimumDamage,normalisedDistance)));
                        }
                    }
                }
            }
        } 
    }

    private void AutoFire()
    {   
       /* if(ammunitionManager.ConsumeAmmo())
        {
            if(gunType==weaponType.automatic)
            {
                if(fireTime <= 0)
                {
                    RaycastHit whatIHit;
                    if (Physics.Raycast(cameraTransform.position, transform.forward, out whatIHit, Mathf.Infinity))
                    {
                        Debug.Log(whatIHit.collider.name);

                        IDamagable damageable = whatIHit.collider.GetComponent<IDamagable>();
                        if (damageable != null)
                        {
                            float normalisedDistance = whatIHit.distance / currentGun.maximumRange;
                            if (normalisedDistance <= 1)
                            {
                                damageable.DealDamage(Mathf.RoundToInt(Mathf.Lerp(currentGun.maximumDamage, currentGun.minimumDamage, normalisedDistance)));
                            }
                            else if (normalisedDistance > 1)
                            {
                                damageable.DealDamage(currentGun.minimumDamage);
                            }
                        }
                    }

                    fireTime = startFireTime;
                }

                else
                {
                    fireTime -= Time.deltaTime;
                }
            }
        }
    }*/
}
