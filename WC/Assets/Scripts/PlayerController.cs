using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    [SerializeField] Rigidbody2D rigidbody2D;
    [SerializeField] float speed = .001f;

    [SerializeField] InputController inputController;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        inputController = GetComponent<InputController>();
    }

    // Update is called once per frame
    void Update()
    {
        //Move Left
        if (SceneManager.GetActiveScene().name == "Game")
        {

            if (inputController.playerInput.Player.Move.ReadValue<Vector2>().x <= -.1f)
            {
                MoveCharacter(inputController.playerInput.Player.Move.ReadValue<Vector2>());
            }

            if (inputController.playerInput.Player.Move.ReadValue<Vector2>().x >= .1f)
            {
                MoveCharacter(inputController.playerInput.Player.Move.ReadValue<Vector2>());
            }
        }
    }

    public void MoveCharacter(Vector2 direction)
    {
       // Vector2 dir = new Vector2(transform.position.x + direction, transform.position.y);
        rigidbody2D.AddForce(direction * speed,ForceMode2D.Impulse);
    }
}
