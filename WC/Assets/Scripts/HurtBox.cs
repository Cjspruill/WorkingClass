using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtBox : MonoBehaviour
{
    [SerializeField] Health health;

    // Start is called before the first frame update
    void Start()
    {
        health = GetComponentInParent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void SendDamage(float damageAmount)
    {
        health.TakeDamage(damageAmount);
    }
}
