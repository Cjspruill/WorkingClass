using System.Collections;
using System.Collections.Generic;
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


    [SerializeField] InputController inputController;
    [SerializeField] Animator animator;
    [SerializeField] BoxCollider2D attackColliderLeft;
    [SerializeField] BoxCollider2D attackColliderRight;
    [SerializeField] bool facingRight;


    private Queue<ComboEntry> comboQueue = new Queue<ComboEntry>();

    private bool attackLocked = false;     // short lock to prevent double triggers
    private float attackLockTimer = 0f;
    private float attackLockDuration = 0.08f; // ~5 frames at 60fps

    private int currentMoveDir = -1;
    private bool currentPunch = true;
    private bool inputConsumedThisFrame = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
        inputController = GetComponent<InputController>();
    }
    void Update()
    {
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
    }

    private void StartAttack(int moveDir, bool punch)
    {
        attackLocked = true;
        attackLockTimer = attackLockDuration;

        currentMoveDir = moveDir;
        currentPunch = punch;

        animator.SetInteger("MoveDir", moveDir);

        if (punch) animator.SetTrigger("Punch");
        else animator.SetTrigger("Kick");
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
        if (punch)
        {
            if (Mathf.Abs(moveInput.x) < 0.1f && Mathf.Abs(moveInput.y) < 0.1f) moveDir = 0;
            else if (moveInput.x > 0.1f) moveDir = 1;
            else if (moveInput.x < -0.1f) moveDir = 2;
            else if (moveInput.y < -0.1f) moveDir = 3;
        }
        else
        {
            if (Mathf.Abs(moveInput.x) < 0.1f && Mathf.Abs(moveInput.y) < 0.1f) moveDir = 0;
            else if (moveInput.x > 0.1f) moveDir = 1;
            else if (moveInput.x < -0.1f) moveDir = 2;
        }
        return moveDir;
    }


    public void EnableAttackColliderLeft(string value)
    {
        if (facingRight) return;

        switch (value)
        {
            case "Enable":
                attackColliderLeft.gameObject.SetActive(true);
                break;
            case "Disable":
                attackColliderLeft.gameObject.SetActive(false);
                break;
        }
    }

    public void EnableAttackColliderRight(string value)
    {

        if (!facingRight) return;

        switch (value)
        {
            case "Enable":
                attackColliderRight.gameObject.SetActive(true);
                break;
            case "Disable":
                attackColliderRight.gameObject.SetActive(false);
                break;
        }
    }
}
