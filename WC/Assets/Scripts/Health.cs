using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    [SerializeField] float health = 10f;
    [SerializeField] public float maxHealth = 100;
    [SerializeField] float healthRegen = 0.25f;
    [SerializeField] float activeTimer;
    [SerializeField] float activeTime;
    [SerializeField] float activeTimeMin = 10f;
    [SerializeField] float activeTimeMax = 15f;

    [SerializeField] float cooldownTimer;
    [SerializeField] float cooldownTime;
    [SerializeField] float cooldownTimeMin = 5f;
    [SerializeField] float cooldownTimeMax = 10f;

    public float GetHealth { get => health; set => health = value; }

    // Start is called before the first frame update
    void Start()
    {
      
        activeTime = Random.Range(activeTimeMin, activeTimeMax);
        cooldownTime = Random.Range(cooldownTimeMin, cooldownTimeMax);
    }

    // Update is called once per frame
    void Update()
    {
        activeTimer++;
        if (activeTimer > activeTime) 
        {
            cooldownTimer++;
            if (cooldownTimer > cooldownTime) 
            {
                activeTimer = 0;
                cooldownTimer = 0;
                GiveHealth(healthRegen);            
            }
        }
    }

    public void TakeDamage(float value)
    
    {
        GetHealth -= value; //health = health - value;    health equals health minus value
        if (GetHealth <= 0)
        {
            Debug.Log("BOOM HEADSHOT");
        }
    }
    public void GiveHealth(float value) 
    {
        GetHealth += value;
        if (GetHealth > 100f) 
        {
            GetHealth = 100f;
        }
    }
}
