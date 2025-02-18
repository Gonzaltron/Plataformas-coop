using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

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
        /*
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            float moveInput = Input.GetAxisRaw("Horizontal");
            rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocityY);
        }
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            rb.linearVelocity = Vector2.zero;
        }
        */
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }

    }
}   

