using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AIController : MonoBehaviour
{
    private enum AIStates
    {
        Idle,
        Chase,
        Attack,
        Rest
    }

    private AIStates curState = AIStates.Idle;

    [Header("General")]
    //Set in start
    [SerializeField] Animator animator;
    [SerializeField] PlayerController playerController;
    [SerializeField] BoxCollider2D groundCollider;
    [SerializeField] Transform opponentTransform;
    //Set in inspector
    [SerializeField] BoxCollider2D attackColliderLeft;
    [SerializeField] BoxCollider2D attackColliderRight;

    [SerializeField] Vector2 groundColliderOrig = new Vector2(-.25f, 1.35f);
    [SerializeField] Vector2 groundColliderFlipped = new Vector2(.25f, 1.35f);

    [SerializeField] bool facingRight;
    [SerializeField] float speed = 2f;
    [SerializeField] float attackRange = 1.5f;
    [SerializeField] float chaseRange = 9f;

    [Header("Combo Settings")]
    [SerializeField] int comboIndex = 0;
    [SerializeField] int maxComboHits = 3;
    [SerializeField] float attackInterval = 0.5f;
    private float attackTimer;

    [Header("Idle Timers")]
    [SerializeField] float idleTimeMin = .25f;
    [SerializeField] float idleTimeMax = 1f;
    private float idleTimer;
    private float idleDuration;

    [Header("Rest Timers")]
    [SerializeField] float restTimeMin = .05f;
    [SerializeField] float restTimeMax = .25f;
    private float restTimer;
    private float restDuration;

    SpriteRenderer spriteRenderer;
    Color origSpriteColor;


    //Attack Transform Setups
    [SerializeField] Transform jabLeftPosition; //Cross uses the jab position as well
    [SerializeField] Transform jabRightPosition;
    [SerializeField] Transform leadHookLeftPosition;
    [SerializeField] Transform leadHookRightPosition;
    [SerializeField] Transform uppercutLeftPosition;
    [SerializeField] Transform uppercutRightPosition;
    [SerializeField] Transform frontKickLeftPostition;
    [SerializeField] Transform frontKickRightPosition;
    [SerializeField] Transform leadSideKickLeftPosition;
    [SerializeField] Transform leadSideKickRightPosition;
    [SerializeField] Transform roundKickLeftPosition;
    [SerializeField] Transform roundKickRightPosition;

    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerController = FindObjectOfType<PlayerController>();
        idleDuration = Random.Range(idleTimeMin, idleTimeMax);
        origSpriteColor = GetComponent<SpriteRenderer>().color;
        groundCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name != "MainMenu")
        {
            if (opponentTransform == null)
            {
                opponentTransform = playerController.transform;
            }
                CheckAndTurnPlayer();
        }


        switch (curState)
        {
            case AIStates.Idle:
                HandleIdle();
                break;
            case AIStates.Chase:
                HandleChase();
                break;
            case AIStates.Attack:
                HandleAttack();
                break;
            case AIStates.Rest:
                HandleRest();
                break;
        }
    }

    void HandleIdle()
    {
        float dist = Vector2.Distance(transform.position, playerController.transform.position);

        if (dist > chaseRange)
        {
            // Player too far, truly idle
            return;
        }

        // Player is close — skip idle and start chasing
        curState = AIStates.Chase;
    }

    void HandleChase()
    {
        float dist = Vector2.Distance(transform.position, playerController.transform.position);

        if (dist <= attackRange)
        {
            StartCombo();
            return;
        }
        else if (dist <= chaseRange)
        {
            // Move toward player
            Vector2 dir = (playerController.transform.position - transform.position).normalized;
            transform.position += (Vector3)(dir * speed * Time.deltaTime);
        }
        else
        {
            // Player far away — back to idle
            curState = AIStates.Idle;
        }
    }

    void StartCombo()
    {
        comboIndex = 0;
        attackTimer = 0;
        curState = AIStates.Attack;
    }

    void HandleAttack()
    {
        attackTimer += Time.deltaTime;
        if (attackTimer >= attackInterval)
        {
            attackTimer = 0;
            comboIndex++;

            bool usePunch = Random.value < 0.5f;
            int moveDir;

            if (usePunch)
            {
                moveDir = Random.Range(0, 4);
                animator.SetInteger("MoveDir", moveDir);
                animator.SetTrigger("Punch");
            }
            else
            {
                moveDir = Random.Range(0, 3);
                animator.SetInteger("MoveDir", moveDir);
                animator.SetTrigger("Kick");
            }

            spriteRenderer.color = Color.green;
            Invoke("CancelAttackColor", 0.1f);

            float dist = Vector2.Distance(transform.position, playerController.transform.position);

            // If combo finished, go to Rest
            if (comboIndex >= maxComboHits)
            {
                curState = AIStates.Rest;
                PrepareRest();
            }
            // If combo not finished but player moves away, also go to Rest
            else if (dist > attackRange && Random.value < 0.1f)
            {
                curState = AIStates.Rest;
                PrepareRest();
            }
        }
    }


    void CancelAttackColor()
    {
        spriteRenderer.color = origSpriteColor;
    }

    void PrepareRest()
    {
        restTimer = 0;
        restDuration = Random.Range(restTimeMin, restTimeMax);
    }

    void HandleRest()
    {
        restTimer += Time.deltaTime;
        float dist = Vector2.Distance(transform.position, playerController.transform.position);

        if (restTimer >= restDuration)
        {
            if (dist <= attackRange)
            {
                // Player still close — start next combo immediately
                StartCombo();
            }
            else if (dist <= chaseRange)
            {
                // Player nearby — chase
                curState = AIStates.Chase;
            }
            else
            {
                // Player far — idle
                curState = AIStates.Idle;
            }
        }
    }

    void CheckAndTurnPlayer()
    {
        if (opponentTransform == null) return;

        //If Opponent is to right of us
        if (opponentTransform.position.x < transform.position.x)
        {
            facingRight = false;
            spriteRenderer.flipX = false;
            groundCollider.offset = groundColliderOrig;
        }
        else
        {
            facingRight = true;
            spriteRenderer.flipX = true;
            groundCollider.offset = groundColliderFlipped;
        }
    }

    public void OnAttackFinished()
    {
        //Just here for stuff
    }

    public void EnableAttackCollider(string value)
    {
        switch (value)
        {
            case "Enable":
                Transform targetTransform = null;

                // Determine target transform based on current animation state
                // Using MoveDir parameter from animator
                int moveDir = animator.GetInteger("MoveDir");
                bool punch = animator.GetCurrentAnimatorStateInfo(0).IsTag("Punch");

                if (punch)
                {
                    switch (moveDir)
                    {
                        case 0:
                        case 1: targetTransform = facingRight ? jabLeftPosition : jabRightPosition; break;
                        case 2: targetTransform = facingRight ? leadHookLeftPosition : leadHookRightPosition; break;
                        case 3: targetTransform = facingRight ? uppercutLeftPosition : uppercutRightPosition; break;
                    }
                }
                else // Kick
                {
                    switch (moveDir)
                    {
                        case 0: targetTransform = facingRight ? frontKickLeftPostition : frontKickRightPosition; break;
                        case 1: targetTransform = facingRight ? roundKickLeftPosition : roundKickRightPosition; break;
                        case 2: targetTransform = facingRight ? leadSideKickLeftPosition : leadSideKickRightPosition; break;
                    }
                }

                if (targetTransform == null) return;

                // Choose which collider to move
                BoxCollider2D colliderToMove = facingRight ? attackColliderRight : attackColliderLeft;

                // Unparent, parent to new attack point, reset local position/rotation
                colliderToMove.transform.parent = null;
                colliderToMove.transform.SetParent(targetTransform, false);
                colliderToMove.transform.localPosition = Vector3.zero;
                colliderToMove.transform.localRotation = Quaternion.identity;

                colliderToMove.enabled = true;
                colliderToMove.GetComponent<SpriteRenderer>().enabled = true;
                break;

            case "Disable":
                if (facingRight)
                {
                    attackColliderRight.enabled = false;
                    attackColliderRight.GetComponent<SpriteRenderer>().enabled = false;
                }
                else
                {
                    attackColliderLeft.enabled = false;
                    attackColliderLeft.GetComponent<SpriteRenderer>().enabled = false;
                }
                break;
        }
    }

    public void DisableColliders()
    {
        attackColliderLeft.enabled = false;
        attackColliderRight.enabled = false;
        attackColliderLeft.GetComponent<SpriteRenderer>().enabled = false;
        attackColliderRight.GetComponent<SpriteRenderer>().enabled = false;
    }


}