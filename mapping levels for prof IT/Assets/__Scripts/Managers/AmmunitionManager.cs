using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmunitionManager : MonoBehaviour
{
    public static AmmunitionManager instance;

    //[SerializeField] private int ammoCount=50;
    [SerializeField] private Text ammoCountText;

    private Dictionary<AmmunitionTypes, int> ammoCounts= new Dictionary<AmmunitionTypes, int>();
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

    private void Start()
    {
        for(int i=0; i < Enum.GetNames(typeof(AmmunitionTypes)).Length; i++) //gets length of ammunitiontypes enum
        {
            ammoCounts.Add((AmmunitionTypes)i,0); //this makes 3 ammo types that start with 0 ammo
        }
    }

    public void AddAmmo(int value, AmmunitionTypes ammunitionType)
    {   
        ammoCounts[ammunitionType]+=value; //passing in a type to the dictionary which gives back an int, then add that to value
        UpdatedAmmoCountUI();
    }

    public bool ConsumeAmmo(AmmunitionTypes ammunitionType)
    {
        if(ammoCounts[ammunitionType]>0)
        {
            ammoCounts[ammunitionType]--;
            UpdatedAmmoCountUI();
            return true; //we have ammo and we reduced it by one
        }

        else
        {
            return false;//if no ammo left return false
        }
       
    }
    
    private void UpdatedAmmoCountUI()
    {
        //ammoCountText.text="Ammo: "+ammoCount;
    }
}
