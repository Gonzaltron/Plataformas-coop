using UnityEngine;

public class Louise : MonoBehaviour
{
    [SerializeField] float jumpForce;
    [SerializeField] float moveSpeed;
    private Rigidbody2D rb;
    private bool isGrounded;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.UpArrow) && isGrounded == true)
        {
            rb.linearVelocity = new Vector3(rb.linearVelocityX, jumpForce);
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))
        {
            float moveInput = Input.GetAxisRaw("Horizontal");
            rb.linearVelocity = new Vector3(moveInput * moveSpeed, rb.linearVelocityY);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            rb.linearVelocity = Vector3.zero;
        }

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
