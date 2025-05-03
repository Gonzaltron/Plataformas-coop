using UnityEngine;

public class Enemigo_Nivel4 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float speed;
    public bool moveRight;
    private Rigidbody2D rbE;

    private Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    void FixedUpdate()
    {
        if (moveRight) // Se mueve hacia la izquierda
        {
            transform.Translate(2 * Time.deltaTime * speed, 0, 0);
            animator.SetBool("IsRight", true); // Activar animación caminar a la izquierda
        }
        else // Se mueve hacia la derecha
        {
            transform.Translate(-2 * Time.deltaTime * speed, 0, 0);
            animator.SetBool("IsRight", false); // Activar animación caminar a la derecha
        }
       
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Steam"))
        {
            moveRight = false;
        }
        else
        {
            moveRight = true;
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Steam"))
        {
            moveRight = false;
        }
        else
        {
            moveRight = true;
        }
    }
}
