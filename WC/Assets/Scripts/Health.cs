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
    [SerializeField] float hurtCooldown = 0.5f; // seconds between hurt triggers
    private bool canBeHurt = true;

    [SerializeField] SpriteRenderer hurtBoxSpriteRenderer;

    [SerializeField] Animator animator;

    public float GetHealth { get => health; set => health = value; }


    private void OnEnable()
    {
        GameManager.OnRoundStart += ResetHealth;
    }

    private void OnDisable()
    {
        GameManager.OnRoundStart -= ResetHealth;
    }

    // Start is called before the first frame update
    void Start()
    {
        hurtBoxSpriteRenderer.enabled = false;
        activeTime = Random.Range(activeTimeMin, activeTimeMax);
        cooldownTime = Random.Range(cooldownTimeMin, cooldownTimeMax);
        animator = GetComponent<Animator>();
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
    if (!canBeHurt) return;

    GetHealth -= value;
    hurtBoxSpriteRenderer.enabled = true;
    animator.SetTrigger("Hurt");

    if (GetHealth <= 0)
    {
        animator.SetTrigger("Knockout");
        // Instead of waiting for round start, we start GetUp here
        StartCoroutine(GetUp());
        GameManager.instance.EndRound();

            if (GetComponent<AIController>() != null)
            {
                GameManager.instance.GetPlayer2Wins++;
            }
            else if (GetComponent<PlayerController>() != null)
            {
                GameManager.instance.GetPlayer1Wins++;
            }
    }

    StartCoroutine(TurnOffHitBox());
    StartCoroutine(HurtCooldownCoroutine());
}
    IEnumerator HurtCooldownCoroutine()
    {
        canBeHurt = false;                // block further hurt triggers
        yield return new WaitForSeconds(hurtCooldown);
        canBeHurt = true;                 // allow hurt triggers again
    }
    public void GiveHealth(float value) 
    {
        GetHealth += value;
        if (GetHealth > 100f) 
        {
            GetHealth = 100f;
        }
    }

    IEnumerator TurnOffHitBox()
    {
        yield return new WaitForSeconds(.15f);
        hurtBoxSpriteRenderer.enabled = false;
    }


    void ResetHealth()
    {
        health = maxHealth;
    }
    
    IEnumerator GetUp()
    {
        yield return new WaitForSeconds(3);
        animator.SetTrigger("RoundStart");
    }
}
