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

    //Normal combo setup
    [SerializeField] bool comboActive;

    [SerializeField] int comboIndex;
    [SerializeField] float comboTimer;
    [SerializeField] float comboTime;
    [SerializeField] float comboTimeMin = .5f;
    [SerializeField] float comboTimeMax = 3f;

    //Create a small timer buffer to slow down the attacks
    [SerializeField] float idleBufferTimer;
    [SerializeField] float idleBufferTime;
    [SerializeField] float idleBufferTimeMin = .5f;
    [SerializeField] float idleBufferTimeMax = 3f;

    //Timer for idle to go back to attacking
    [SerializeField] float idleTimer;
    [SerializeField] float idleTime;
    [SerializeField] float idleTimeMin = 3f;
    [SerializeField] float idleTimeMax = 8f;


    //Sprite renederer for visual color info
    [SerializeField] SpriteRenderer spriteRenderer;

    [SerializeField] PlayerController playerReference;
    [SerializeField] float distance;
    [SerializeField] float speed;
    
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        comboTime = Random.Range(comboTimeMin, comboTimeMax);
        idleBufferTime = Random.Range(idleBufferTimeMin, idleBufferTimeMax);
        idleTime = Random.Range(idleTimeMin, idleTimeMax);

        playerReference = FindObjectOfType<PlayerController>();
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

                if (comboActive)
                {
                    idleBufferTimer++;

                    if (idleBufferTimer > idleBufferTime)
                    {
                        idleBufferTimer = 0;
                        idleBufferTime = Random.Range(idleBufferTimeMin, idleBufferTimeMax);
                        TryAttack();
                    }
                }
                else
                {
                    idleTimer++;

                    if(idleTimer > idleTime)
                    {
                        idleTimer = 0;
                        //Chase first, then attack
                        curState = AIStates.Chase;
                    }
                }



                break;
            case AIStates.Chase:
                distance = Vector2.Distance(transform.position, playerReference.transform.position);
                Vector2 direction = playerReference.transform.position - transform.position;
                direction.Normalize();

                if (distance < 9 && distance >= 1.5)
                {
                    transform.position = Vector2.MoveTowards(this.transform.position, playerReference.transform.position, speed * Time.deltaTime);
                }
                else if (distance < 1.5f)
                {
                    TryAttack();

                }

                break;
            case AIStates.Attack:

                comboTimer++;

                if(comboTimer> comboTime)
                {
                    if(comboIndex <= 3)
                    {
                        comboIndex++;
                        comboTimer = 0;
                        comboTime = Random.Range(comboTimeMin,comboTimeMax);
                        spriteRenderer.color = Color.red;
                        Invoke("CancelAttack", .1f);
                        comboActive = true;
                        curState = AIStates.Idle;
                    }
                    
                    if (comboIndex > 3)
                    {
                        comboIndex = 0;
                        comboActive = false;
                    }
                }
                break;
        }
    }


    public void TryAttack()
    {
        int randVal = Random.Range(0,500);
        
       if(randVal <= 1)
        {
            curState = AIStates.Attack;
        }
    }

    public void CancelAttack()
    {
        spriteRenderer.color = Color.white;
    }
}
