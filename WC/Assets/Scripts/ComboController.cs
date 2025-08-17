using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ComboController : MonoBehaviour
{
    private struct ComboEntry
    {
        public int moveDir;
        public bool punch;
        public ComboEntry(int moveDir, bool punch)
        {
            this.moveDir = moveDir;
            this.punch = punch;
        }
    }

    private Queue<ComboEntry> comboQueue = new Queue<ComboEntry>();

    //Set in start
    [SerializeField] Animator animator;
    [SerializeField] InputController inputController;
    [SerializeField] PlayerController playerController;
    [SerializeField] BoxCollider2D groundCollider;
    //Filled from inspector
    [SerializeField] BoxCollider2D attackColliderLeft;
    [SerializeField] BoxCollider2D attackColliderRight;
 
    [SerializeField] Vector2 groundColliderOrig = new Vector2(-.25f, 1.35f);
    [SerializeField] Vector2 groundColliderFlipped = new Vector2(.25f, 1.35f);

    [SerializeField] bool facingRight;
    [SerializeField] public bool attackLocked = false;     // short lock to prevent double triggers
    [SerializeField] float attackLockTimer = 0f;
    [SerializeField] float attackLockDuration = 0.5f; // ~5 frames at 60fps
    [SerializeField] int currentMoveDir = -1;
    [SerializeField] bool currentPunch = true;
    [SerializeField] bool inputConsumedThisFrame = false;

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


    private void Start()
    {
        animator = GetComponent<Animator>();
        inputController = GetComponent<InputController>();
        playerController = GetComponent<PlayerController>();
        groundCollider = GetComponent<BoxCollider2D>();
    }
    void Update()
    {
        facingRight = playerController.spriteRenderer.flipX;

        if (!facingRight)        
            groundCollider.offset = groundColliderOrig; 
        else  
            groundCollider.offset = groundColliderFlipped;
        

        inputConsumedThisFrame = false;

        // Decrease short lock timer
        if (attackLocked)
        {
            attackLockTimer -= Time.deltaTime;
            if (attackLockTimer <= 0f) attackLocked = false;
        }

        Vector2 moveInput = inputController.playerInput.Player.Move.ReadValue<Vector2>();
        bool punchPressed = inputController.playerInput.Player.Punch.triggered;
        bool kickPressed = inputController.playerInput.Player.Kick.triggered;
        bool isBlocking = playerController.isBlocking;

        if ((punchPressed || kickPressed) && !inputConsumedThisFrame)
        {
            bool punch = punchPressed;
            int moveDir = GetMoveDir(moveInput, punch);

            if (!attackLocked)
            {
                StartAttack(moveDir, punch);
                inputConsumedThisFrame = true;
            }
            else if (moveDir != currentMoveDir || punch != currentPunch)
            {
                comboQueue.Enqueue(new ComboEntry(moveDir, punch));
                inputConsumedThisFrame = true;
            }
        }


        animator.SetBool("IsBlocking", isBlocking);
        
    }

    private void StartAttack(int moveDir, bool punch)
    {

        if (!playerController.onGround) return;
        // Lock the attack to prevent double triggers
        attackLocked = true;
        attackLockTimer = attackLockDuration;

        // Store the current attack info
        currentMoveDir = moveDir;
        currentPunch = punch;

        // Set Animator parameters
        animator.SetInteger("MoveDir", moveDir);

        if (punch)
            animator.SetTrigger("Punch");
        else
            animator.SetTrigger("Kick");
    }

    // Animation Event at the end of each attack
    public void OnAttackFinished()
    {
        currentMoveDir = -1;

        if (comboQueue.Count > 0)
        {
            ComboEntry next = comboQueue.Dequeue();
            StartAttack(next.moveDir, next.punch);
        }
    }

    private int GetMoveDir(Vector2 moveInput, bool punch)
    {
        int moveDir = 0;

        if (facingRight)
        {
            if (Mathf.Abs(moveInput.x) < 0.1f && Mathf.Abs(moveInput.y) < 0.1f) moveDir = 0;
            else if (moveInput.x > 0.1f) moveDir = 2; // RIGHT input while facing right = backward attack
            else if (moveInput.x < -0.1f) moveDir = 1; // LEFT input while facing right = forward attack
        }
        else
        {
            if (Mathf.Abs(moveInput.x) < 0.1f && Mathf.Abs(moveInput.y) < 0.1f) moveDir = 0;
            else if (moveInput.x < -0.1f) moveDir = 2; // LEFT input while facing left = backward attack
            else if (moveInput.x > 0.1f) moveDir = 1; // RIGHT input while facing left = forward attack
        }

        if (punch && moveInput.y < -0.1f)
        {
            moveDir = 3;
        }

        return moveDir;
    }

    public void EnableAttackCollider(string value)
    {
        // Choose which collider to move
        BoxCollider2D colliderToMove = facingRight ? attackColliderLeft : attackColliderRight;

        // Determine target attack transform based on current attack
        Transform targetTransform = null;

        if (currentPunch)
        {
            switch (currentMoveDir)
            {
                case 0:
                case 1: targetTransform = facingRight ? jabLeftPosition : jabRightPosition; break;
                case 2: targetTransform = facingRight ? leadHookLeftPosition : leadHookRightPosition; break;
                case 3: targetTransform = facingRight ? uppercutLeftPosition : uppercutRightPosition; break;
            }
        }
        else // Kick
        {
            switch (currentMoveDir)
            {
                case 0: targetTransform = facingRight ? frontKickLeftPostition : frontKickRightPosition; break;
                case 1: targetTransform = facingRight ? roundKickLeftPosition : roundKickRightPosition; break;
                case 2: targetTransform = facingRight ? leadSideKickLeftPosition : leadSideKickRightPosition; break;
            }
        }

        // Update position & rotation before enabling
        if (targetTransform != null)
        {
            colliderToMove.transform.position = targetTransform.position;
            colliderToMove.transform.rotation = targetTransform.rotation;
        }

        // Enable/Disable collider
        switch (value)
        {
            case "Enable":
                colliderToMove.enabled = true;
                colliderToMove.GetComponent<SpriteRenderer>().enabled = true;
                break;
            case "Disable":
                colliderToMove.enabled = false;
                colliderToMove.GetComponent<SpriteRenderer>().enabled = false;
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
