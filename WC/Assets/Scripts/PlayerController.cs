using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    [SerializeField] Rigidbody2D rigidbody2D;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] float speed = .001f;
    [SerializeField] float jumpPower = 50f;

    [SerializeField] InputController inputController;

    [SerializeField] bool onGround = true;

    [SerializeField] Transform opponentTransform;

    // Start is called before the first frame update
    void Start()
    {
        onGround = true;
        rigidbody2D = GetComponent<Rigidbody2D>();
        inputController = GetComponent<InputController>();
        spriteRenderer = GetComponent<SpriteRenderer>();


    }

    // Update is called once per frame
    void Update()
    {
        //Move Left
        if (SceneManager.GetActiveScene().name == "Game")
        {
            if (opponentTransform == null)
            {
                opponentTransform = FindObjectOfType<AIController>().transform;

            }

            if (inputController.playerInput.Player.Move.ReadValue<Vector2>().x <= -.1f)
            {
                MoveCharacter(inputController.playerInput.Player.Move.ReadValue<Vector2>());
            }

            if (inputController.playerInput.Player.Move.ReadValue<Vector2>().x >= .1f)
            {
                MoveCharacter(inputController.playerInput.Player.Move.ReadValue<Vector2>());
            }

            if(inputController.playerInput.Player.Move.ReadValue<Vector2>().y > .1 && onGround)
            {
                Jump();
            }

            CheckAndTurnPlayer();

        }
    }

    public void MoveCharacter(Vector2 direction)
    {
        transform.position += (Vector3)direction * speed * Time.deltaTime; 
        //rigidbody2D.AddForce(direction * speed,ForceMode2D.Impulse);
    }

    public void Jump()
    {
        rigidbody2D.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        onGround = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            onGround = true;
        }
    }


    void CheckAndTurnPlayer()
    {
        //If Opponent is to right of us
        if(opponentTransform.position.x > transform.position.x)
        {
            spriteRenderer.flipX = false;
        }
        else
        {
            spriteRenderer.flipX=true;
        }
    }
}
