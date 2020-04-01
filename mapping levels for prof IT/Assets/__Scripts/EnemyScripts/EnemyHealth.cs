using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour,IDamagable
{
    [SerializeField] public EnemyStats enemyStats;
    [SerializeField] private Slider healthBarSlider;
    [SerializeField] private Image healthbarColorImage;
    [SerializeField] private Color maxHealthColor;
    [SerializeField] private Color zeroHealthColour;
    [SerializeField] private GameObject damageTextPrefab;
    private int currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth=enemyStats.enemyMaxHealth; //as soon as enemy appears, set its health
        SetHealthbarUI();
    }

    // Update is called once per frame
    void Update()
    {
      if(currentHealth==100)
      {
          healthBarSlider.gameObject.SetActive(false); //if enemy is full health do not show the health bar
      }

      else
      {
          healthBarSlider.gameObject.SetActive(true);
      }


    }

    public void DealDamage(int damage)
    {
        currentHealth-=damage;
        Instantiate(damageTextPrefab, transform.position, Quaternion.identity).GetComponent<DamageText>().Initialise(damage);
        CheckIfDead();
        SetHealthbarUI();
    }

    private void CheckIfDead()
    {
        if(currentHealth<=0)
        {
            Destroy(gameObject);
        }
    }

    private void SetHealthbarUI()
    {
        float healthPercentage=CalculateHealthPercentage();
        healthBarSlider.value=healthPercentage;//set the health bar to the calculate health 
        //changes the health bar linearly from set max color to a zero health color
        healthbarColorImage.color=Color.Lerp(zeroHealthColour,maxHealthColor,healthPercentage/100);
    }

    private float CalculateHealthPercentage()
    {
        return ((float)currentHealth/(float)enemyStats.enemyMaxHealth) *100; //cast health values to floats    }
    }
}
