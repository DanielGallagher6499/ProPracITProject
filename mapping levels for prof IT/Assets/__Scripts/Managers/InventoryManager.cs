using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{   
    public static InventoryManager instance;
    
    private void Awake()
    {
        if(instance==null)
        {
            instance=this; //if theres no instance of the class, set it to this one
        }

        else if(instance!=this)
        {
            Destroy(this); //prevents duplicates
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
