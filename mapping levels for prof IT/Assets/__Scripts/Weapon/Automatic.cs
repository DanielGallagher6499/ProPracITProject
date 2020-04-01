using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="Automatic Gun",menuName="Guns/Automatic")]
public class Automatic : Gun
{   
    public float fireRate;
    private float lastTimeFired;

     private void OnEnable()
    {
       lastTimeFired=0f;
    }

   /* private void onDisable()
    {
        lastTimeFired=0f;
    }*/

    public override void OnMouseHold(Transform cameraPos)
    {   
        //total time youve been running
        if(Time.time - lastTimeFired > 1 / fireRate)
        {   
           
            lastTimeFired=Time.time;
            Fire(cameraPos);
        } 
    }        
 
}
