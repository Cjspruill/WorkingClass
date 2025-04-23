using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{

    [SerializeField]public PlayerInput playerInput;

    [SerializeField] InputAction moveAction;
    [SerializeField] InputAction punchAction;
    [SerializeField] InputAction kickAction;

    //Moves the player
    [SerializeField] PlayerController playerController;
    //Attacks the opponent
    [SerializeField] ComboController comboController;

    public void OnEnable()
    {
        playerInput = new PlayerInput();

        playerInput.Player.Enable();
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
        playerController = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
