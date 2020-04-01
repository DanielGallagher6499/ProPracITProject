using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamageText : MonoBehaviour
{
    [SerializeField] private float destroyTime;
    [SerializeField] private Vector3 offset; 
    [SerializeField] private Color damageColor;

    private TextMeshPro damageText;
    
    private void Awake()
    {
        damageText=GetComponent<TextMeshPro>();
        transform.localPosition+=offset; //shifts the position of the text spawn from the middle of the enemy
        Destroy(gameObject,destroyTime); //destroy text after a certain time
    }

    public void Initialise(int damageValue)
    {
        damageText.text = damageValue.ToString(); //when initialised from somewhere else, allows us to set the text
    }

}
