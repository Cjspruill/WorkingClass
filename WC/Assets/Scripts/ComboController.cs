using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboController : MonoBehaviour
{
    [SerializeField] InputController inputController;
    [SerializeField] Animator animator;

    [SerializeField] BoxCollider2D attackColliderLeft;
    [SerializeField] BoxCollider2D attackColliderRight;


    [SerializeField] bool facingRight;

    private bool isAttacking = false;

    private bool punchPressed;
    private bool kickPressed;

    // Start is called before the first frame update
    void Start()
    {
        inputController = GetComponent<InputController>();
        animator = GetComponent<Animator>();
        facingRight = GetComponent<SpriteRenderer>().flipX;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveInput = inputController.playerInput.Player.Move.ReadValue<Vector2>();

        // Buffer the inputs
        if (inputController.playerInput.Player.Punch.triggered)
            punchPressed = true;

        if (inputController.playerInput.Player.Kick.triggered)
            kickPressed = true;

        AnimatorStateInfo state = animator.GetCurrentAnimatorStateInfo(0);

        // Determine punch type based on movement
        int punchType = 0; // default
        if (moveInput.x > 0.1f) punchType = 1;    // forward
        else if (moveInput.y < -0.1f) punchType = 2; // down
        else if (moveInput.x < -0.1f) punchType = 3;  // back

        // Punch
        if (punchPressed && !state.IsTag("Punch"))
        {
            animator.SetInteger("PunchType", punchType);
            animator.SetTrigger("Punch");
            punchPressed = false;
        }

        // Determine kick type based on movement
        int kickType = 0; // default
        if (moveInput.x > 0.1f) kickType = 1;    // forward
        else if (moveInput.y < -0.1f) kickType = 2; // down
        else if (moveInput.x < -0.1f) kickType = 3;  // back

        // Kick
        if (kickPressed && !state.IsTag("Kick"))
        {
            animator.SetInteger("KickType", kickType);
            animator.SetTrigger("Kick");
            kickPressed = false;
        }
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
