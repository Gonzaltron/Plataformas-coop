using UnityEngine;
using UnityEngine.InputSystem;

public class Louise : MonoBehaviour
{
    private InputAction MoveLouise;
    [SerializeField] float jumpForce;
    [SerializeField] float moveSpeed;
    private Rigidbody2D rb;
    private bool isGrounded;

    public bool isMovingplatform;
    public GameObject detectorground;
    bool jumpOn;
    private Animator animator; // Referencia al Animator
    private bool isOnLadder = false; // Variable para detectar si está en la escalera
    private bool isTouchingBox = false; // Variable para detectar si está tocando una caja
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        MoveLouise = InputSystem.actions.FindAction("MoveLouise");
        animator = GetComponent<Animator>(); // Obtener el Animator
        jumpOn = false;
        isMovingplatform = false;

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveValue = MoveLouise.ReadValue<Vector2>();
        bool isMoving = Mathf.Abs(moveValue.x) > 0.1f;

        // Animación de la escalera
        if (isOnLadder)
        {
            animator.SetBool("isWalkingRight", false);
            animator.SetBool("isWalkingLeft", false);
            animator.SetBool("isPushingBox", false); 
            animator.SetBool("isOnLadder", true);
            return; 
        }
        else
        {
            animator.SetBool("isOnLadder", false); 
        }

        if (isTouchingBox && isMoving)
        {
            animator.SetBool("isPushingBox", true);

            if (moveValue.x > 0)
            {
                animator.SetBool("isWalkingRight", true);
                animator.SetBool("isWalkingLeft", false);
            }
            else if (moveValue.x < 0)
            {
                animator.SetBool("isWalkingRight", false);
                animator.SetBool("isWalkingLeft", true);
            }
        }
        else
        {
            animator.SetBool("isPushingBox", false);

            
            if (moveValue.x > 0)
            {
                animator.SetBool("isWalkingRight", true);
                animator.SetBool("isWalkingLeft", false);
            }
            else if (moveValue.x < 0)
            {
                animator.SetBool("isWalkingRight", false);
                animator.SetBool("isWalkingLeft", true);
            }
            else
            {
                animator.SetBool("isWalkingRight", false);
                animator.SetBool("isWalkingLeft", false);
            }
        }

        animator.SetFloat("Speed", Mathf.Abs(moveValue.x));

    }


    private void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(detectorground.transform.position, -Vector2.up, 10f);
        if (hit.collider != null)
        {
            if (hit.distance <= 0.3)
            {
                jumpOn = true;
            }
            else
            {
                jumpOn = false;
            }
        }
            
        
       
        if (MoveLouise.IsPressed())
        {
            Vector2 moveValue = MoveLouise.ReadValue<Vector2>();
            rb.linearVelocity = new Vector2(moveValue.x * moveSpeed, rb.linearVelocityY);
        }
        if (Input.GetKey(KeyCode.Space) && isGrounded == true && jumpOn == true)
        {

            rb.linearVelocity = new Vector2(rb.linearVelocityX, jumpForce);

        }



    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Box"))
        {
            isGrounded = true;
        }
        if (collision.gameObject.CompareTag("Box"))
        {
            isGrounded = true;
            moveSpeed /= 2;

        }
        if (collision.gameObject.CompareTag("Switch"))
        {
            isGrounded = false;
        }
        if (collision.gameObject.CompareTag("Ladder"))
        {
            isOnLadder = true; // El personaje está en la escalera
        }
        if (collision.gameObject.CompareTag("Box"))
        {
            isTouchingBox = true; // El personaje está tocando una caja
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Box") || collision.gameObject.CompareTag("Switch"))
        {
            isGrounded = false;
           
        }
        if (collision.gameObject.CompareTag("Box"))
        {
            isGrounded = false;
            moveSpeed *= 2;
            isTouchingBox = false;
            animator.SetBool("isPushingBox", false); // Desactivar animación de empujar caja
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ladder"))
        {
            isOnLadder = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ladder"))
        {
            isOnLadder = false;
            animator.SetBool("isBackwards", false);
        }
  
    }
}
