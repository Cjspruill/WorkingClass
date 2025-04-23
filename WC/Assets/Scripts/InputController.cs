using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{

    [SerializeField] PlayerInput playerInput;

    [SerializeField] InputAction moveAction;
    [SerializeField] InputAction punchAction;
    [SerializeField] InputAction kickAction;

    //Moves the player
    [SerializeField] PlayerController playerController;
    //Attacks the opponent
   // [SerializeField] 

    public void OnEnable()
    {
        playerInput = new PlayerInput();

        playerInput.Player.Enable();

        playerInput.Player.Move.performed += SetMovement;
    }

    public void OnDisable()
    {
        playerInput.Player.Disable();
    }

    private void Awake()
    {

    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetMovement(InputAction.CallbackContext ctx)
    {
        //Pass this to controller
       Vector2 moveInput = ctx.ReadValue<Vector2>();

    }

}
