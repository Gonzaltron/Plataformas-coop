using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player1;
    public Transform player2;
    public float detectionRadius = 5.0f;
    public float speed = 5.0f;

    private Rigidbody2D rb;
    private Vector2 movement;
    private bool isTouchingGround = false;

    private Animator animator;  // Referencia al Animator

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();  // Obtener el Animator del enemigo
    }

    // Update is called once per frame
    void Update()
    {
        float DistanceToPlayer1 = Vector2.Distance(transform.position, player1.position);
        float DistanceToPlayer2 = Vector2.Distance(transform.position, player2.position);

        Transform targetPlayer = null;

        if (DistanceToPlayer1 < DistanceToPlayer2)
        {
            targetPlayer = player1;
        }
        else
        {
            targetPlayer = player2;
        }

        if (targetPlayer != null && Vector2.Distance(transform.position, targetPlayer.position) < detectionRadius)
        {
            Vector2 direction = (targetPlayer.position - transform.position).normalized;
            movement = new Vector2(direction.x, 0);
        }
        else if (isTouchingGround)
        {
            movement = new Vector2(-movement.x, 0);
        }
        else
        {
            movement = new Vector2(movement.x, 0);
        }

        // Cambiar animación dependiendo de la dirección del movimiento
        if (movement.x > 0)  // Se mueve hacia la derecha
        {
            animator.SetBool("IsRight", true);  // Activar animación caminar a la derecha
        }
        else if (movement.x < 0)  // Se mueve hacia la izquierda
        {
            animator.SetBool("IsRight", false);  // Activar animación caminar a la izquierda
        }

        rb.MovePosition(rb.position + movement * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Box"))
        {
            isTouchingGround = true;
            movement = new Vector2(-movement.x, 0);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Box"))
        {
            isTouchingGround = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Box"))
        {
            isTouchingGround = true;
            movement = new Vector2(-movement.x, 0);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Box"))
        {
            isTouchingGround = false;
        }
    }
}
