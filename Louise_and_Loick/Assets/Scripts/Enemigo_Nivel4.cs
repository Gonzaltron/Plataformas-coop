using UnityEngine;

public class Enemigo_Nivel4 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float speed; //velocidad a la que se mueve el enemigo
    public bool moveRight;
    private Rigidbody2D rbE;
    public bool isDead;


    public Vector3 resetPositionEnemy;
    [SerializeField] private Transform Enmy;
    private Animator animator;
    
    private void Start()
    {
        animator = GetComponent<Animator>();
        isDead = false;
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

    //al entrar en colision
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //si es co algo de esto
        if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Box"))
        {
            moveRight = !moveRight; //cambia la direccion del enemigo
        }
        else if (collision.gameObject.CompareTag("Steam"))
        {
            Enmy.transform.position = resetPositionEnemy;
            isDead = true;

        }

    }

    //al entrar en trigger
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //si es con algo de esto
        if (collision.gameObject.CompareTag("Wall")|| collision.gameObject.CompareTag("Box"))
        {
            moveRight = !moveRight; //cambia la direccion del enemigo
        }
        else if (collision.gameObject.CompareTag("Steam"))
        {
            Enmy.transform.position = resetPositionEnemy;
            isDead = true;

        }
    }
}
