using UnityEngine;
using UnityEngine.InputSystem;

public class Loick : MonoBehaviour
{
    private InputAction MoveLoick;
    [SerializeField] float jumpForce;
    [SerializeField] float moveSpeed;
    private Rigidbody2D rb;
    private bool isGrounded;
    private Animator animator; // Referencia al Animator

    public bool isMovingplatform;
    public GameObject detectorGround;
    bool jumpOn;

    private bool isOnLadder = false; // Variable para detectar si está en la escalera

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        MoveLoick = InputSystem.actions.FindAction("MoveLoick");
        animator = GetComponent<Animator>(); // Obtener el Animator
        isMovingplatform = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Obtener el valor de movimiento
        Vector2 moveValue = MoveLoick.ReadValue<Vector2>();
        bool isMoving = Mathf.Abs(moveValue.x) > 0.1f; // Verificar si se está moviendo

        // Si está en la escalera, mostrar la animación de espaldas
        if (isOnLadder)
        {
            animator.SetBool("isWalkingRight", false);  // Desactivar caminar hacia la derecha
            animator.SetBool("isWalkingLeft", false);   // Desactivar caminar hacia la izquierda
            animator.SetBool("isBackwards", true);      // Activar animación de espaldas
        }
        else
        {
            
            animator.SetFloat("Speed", Mathf.Abs(moveValue.x)); // Establecer la velocidad para las animaciones y caminar

            // Animaciones de caminar
            if (moveValue.x > 0)
            {
                animator.SetBool("isWalkingRight", true);  // Activar caminar a la derecha
                animator.SetBool("isWalkingLeft", false);  // Desactivar caminar a la izquierda
                animator.SetBool("isBackwards", false);    // Desactivar animación de espaldas
            }
            else if (moveValue.x < 0)
            {
                animator.SetBool("isWalkingRight", false); // Desactivar caminar a la derecha
                animator.SetBool("isWalkingLeft", true);   // Activar caminar a la izquierda
                animator.SetBool("isBackwards", false);    // Desactivar animación de espaldas
            }
            else
            {
                animator.SetBool("isWalkingRight", false); // Desactivar caminar a la derecha
                animator.SetBool("isWalkingLeft", false);  // Desactivar caminar a la izquierda
                animator.SetBool("isBackwards", false);    // Desactivar animación de espaldas
            }
        }
    }

    private void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(detectorGround.transform.position, -Vector2.up, 10f);
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
        if (MoveLoick.IsPressed())
        {
            Vector2 moveValue = MoveLoick.ReadValue<Vector2>();
            rb.linearVelocity = new Vector2(moveValue.x * moveSpeed, rb.linearVelocityY);
        }
        if (Input.GetKey(KeyCode.UpArrow) && isGrounded == true && jumpOn == true)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocityX, jumpForce);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            return;
        }
        if (collision.gameObject.CompareTag("Box"))
        {
            isGrounded = true;
            return;
        }
        if (collision.gameObject.CompareTag("Switch"))
        {
            isGrounded = false;
            return;
        }
        if (collision.gameObject.CompareTag("Ladder"))
        {
            isOnLadder = true; // Loick está en la escalera
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

