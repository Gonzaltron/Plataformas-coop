using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class Loick : MonoBehaviour
{

    private InputAction MoveLoick;
    [SerializeField] float jumpForce;
    [SerializeField] float moveSpeed;
    private Rigidbody2D rb;
    private bool isGrounded;
    
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        MoveLoick = InputSystem.actions.FindAction("MoveLoick");
    }

    // Update is called once per frame
    void Update()
    {
        

    }
    private void FixedUpdate()
    {
        if (MoveLoick.IsPressed())
        {
            Vector2 moveValue = MoveLoick.ReadValue<Vector2>();
            rb.linearVelocity = new Vector2(moveValue.x * moveSpeed, rb.linearVelocityY);
        }
        if (Input.GetKey(KeyCode.UpArrow) && isGrounded == true)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocityX, jumpForce);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        if (collision.gameObject.CompareTag("Box"))
        {
            isGrounded = true;
        }
        if (collision.gameObject.CompareTag("Switch"))
        {
            isGrounded = false;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Switch"))
        {
            isGrounded = false;

        }
        if (collision.gameObject.CompareTag("Box"))
        {
            isGrounded = false;
        }
    }
}   

