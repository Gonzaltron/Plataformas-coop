using UnityEngine;
using UnityEngine.InputSystem;

public class Louise : MonoBehaviour
{
    private InputAction MoveLouise;
    [SerializeField] float jumpForce;
    [SerializeField] float moveSpeed;
    private Rigidbody2D rb;
    private bool isGrounded;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        MoveLouise = InputSystem.actions.FindAction("MoveLouise");
        
    }

    // Update is called once per frame
    void Update()
    {

        

    }
    private void FixedUpdate()
    {
       

        if (MoveLouise.IsPressed())
        {
            Vector2 moveValue = MoveLouise.ReadValue<Vector2>();
            rb.linearVelocity = new Vector2(moveValue.x * moveSpeed, rb.linearVelocityY);
        }
        if (Input.GetKey(KeyCode.Space) && isGrounded == true)
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
            moveSpeed /= 2;

        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
           
        }
        if (collision.gameObject.CompareTag("Box"))
        {
            isGrounded = false;
            moveSpeed *= 2;

        }
    }
}
