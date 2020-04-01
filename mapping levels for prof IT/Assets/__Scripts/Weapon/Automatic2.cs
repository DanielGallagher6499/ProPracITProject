using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Automatic2 : Gun
{
  /* public float startFireTime;
    private float fireTime=0;

    public override void OnMouseHold(Transform cameraPos)
    {   
        if(fireTime <= 0)
        {
            RaycastHit whatIHit;
            if (Physics.Raycast(cameraPos.position, cameraPos.transform.forward, out whatIHit, Mathf.Infinity))
            {
                Debug.Log(whatIHit.collider.name);

                IDamagable damageable = whatIHit.collider.GetComponent<IDamagable>();
                if (damageable != null)
                {
                    float normalisedDistance = whatIHit.distance / maximumRange;
                    if (normalisedDistance <= 1)
                    {
                        damageable.DealDamage(Mathf.RoundToInt(Mathf.Lerp(maximumDamage, minimumDamage, normalisedDistance)));
                    }
                    else if (normalisedDistance > 1)
                    {
                        damageable.DealDamage(minimumDamage);
                    }
                }
            }
            fireTime = startFireTime;
        }
        else
        {
            fireTime -= Time.deltaTime;
        }
    }*/
}
