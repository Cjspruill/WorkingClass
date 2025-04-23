using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{

    //Ai states
    [SerializeField] enum AIStates
    {
        Idle,
        Chase,
        Attack
    }

    //Current ai state
    [SerializeField] AIStates curState;


    [SerializeField] int comboIndex;
    [SerializeField] float comboTimer;
    [SerializeField] float comboTime;
    [SerializeField] float comboTimeMin = .25f;
    [SerializeField] float comboTimeMax = 3f;

    [SerializeField] bool canAttack;

    [SerializeField] SpriteRenderer spriteRenderer;
    
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        comboTime = Random.Range(comboTimeMin, comboTimeMax);
    }

    // Update is called once per frame
    void Update()
    {
        //If we fall below this position reset us above ground.
        if (transform.position.y <= -10)
        {
            transform.position = new Vector2(transform.position.x, 10);
        }

        //Have to switch somewhere in the code
        switch (curState)
        {
            case AIStates.Idle:
                break;
            case AIStates.Chase:
                break;
            case AIStates.Attack:

              comboTimer++;
               


                if(comboTimer >= comboTime && comboIndex <= 3)
                {
                    comboTimer = 0;
                    comboIndex++;
                    canAttack = true;
                    spriteRenderer.color = Color.red;
                    Invoke("CancelAttack", .1f);
                    comboTime = Random.Range(comboTimeMin, comboTimeMax);

               
                        TryAttack();
                    
                }
                else if(comboIndex > 3)
                {
                    comboIndex = 0;
                }

                break;
        }
    }


    public void TryAttack()
    {
        int randVal = Random.Range(0,10000);
        
       if(randVal <= 1)
        {
            curState = AIStates.Attack;
        }
    }

    public void CancelAttack()
    {
        canAttack = false;
        spriteRenderer.color = Color.white;
    }
}
