using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BillboardUI : MonoBehaviour {

    public Camera cam;

    void Update () 
    {
        //rotates object so that it is always facing the player
        transform.LookAt(transform.position + cam.transform.rotation * Vector3.forward, cam.transform.rotation * Vector3.up); 
    }
   
}

