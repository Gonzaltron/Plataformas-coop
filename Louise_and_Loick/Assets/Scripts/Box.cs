using UnityEngine;

public class BoxPushable : MonoBehaviour
{
    private Rigidbody2D rbB;
    private bool isTouchingLoick = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rbB = GetComponent<Rigidbody2D>();
        rbB.gravityScale = 1; // Asegura que la gravedad est� activada
        rbB.bodyType = RigidbodyType2D.Dynamic; // La caja comienza como din�mica
    }

    // Update is called once per frame
    void Update()
    {
        if (!isTouchingLoick && rbB.bodyType != RigidbodyType2D.Dynamic) //Asegura que la caja empiece din�mica si no est� tocando a Loick
        {
            rbB.bodyType = RigidbodyType2D.Dynamic; 
            rbB.gravityScale = 1; 
        }
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, 10f);
        if (hit.collider == null)
        {
            rbB.linearVelocityX = 0;
            rbB.linearVelocityY = -5;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Loick")) // Se convierte en est�tica solo cuando Loick la toca
        {
            rbB.bodyType = RigidbodyType2D.Static;
            isTouchingLoick = true;
            rbB.gravityScale = 0; // Desactiva la gravedad cuando es est�tica
        }
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
       
        if (collision.gameObject.CompareTag("Loick")) // Se convierte en din�mica cuando Loick deja de tocarla
        {
            isTouchingLoick = false;
            rbB.bodyType = RigidbodyType2D.Dynamic; 
            rbB.gravityScale = 1; 
        }
    }
}
