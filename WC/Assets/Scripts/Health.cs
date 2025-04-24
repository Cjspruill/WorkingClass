using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    [SerializeField] float health = 100f;
    [SerializeField] float healthRegen = 0.25f;
    [SerializeField] float activeTimer;
    [SerializeField] float activeTime;
    [SerializeField] float activeTimeMin = 10f;
    [SerializeField] float activeTimeMax = 15f;

    [SerializeField] float cooldownTimer;
    [SerializeField] float cooldownTime;
    [SerializeField] float cooldownTimeMin = 5f;
    [SerializeField] float cooldownTimeMax = 10f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("GiveHealth",0,healthRegen);
        activeTime = Random.Range(activeTimeMin, activeTimeMax);
        cooldownTime = Random.Range(cooldownTimeMin, cooldownTimeMax);
    }

    // Update is called once per frame
    void Update()
    {
        activeTimer++;
        if (activeTimer > activeTime) 
        {
            CancelInvoke("GiveHealth");
            cooldownTimer++;
            if (cooldownTimer > cooldownTime) 
            {
                activeTimer = 0;
                cooldownTimer = 0;
                InvokeRepeating("GiveHealth",0,healthRegen);
                
            }
        }
    }

    public void TakeDamage(float value)
    
    {
        health -= value; //health = health - value;    health equals health minus value
        if (health <= 0)
        {
            Debug.Log("BOOM HEADSHOT");
        }
    }
    public void GiveHealth(float value) 
    {
        health += value;
        if (health > 100f) 
        {
            health = 100f;
        }
    }
}
