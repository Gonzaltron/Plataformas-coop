using UnityEngine;

public class BoxPushable : MonoBehaviour
{
    private Rigidbody2D rbB;
    private bool isTouchingLoick = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rbB = GetComponent<Rigidbody2D>();
        rbB.gravityScale = 1; // Asegura que la gravedad esté activada
        rbB.bodyType = RigidbodyType2D.Dynamic; // La caja comienza como dinámica
    }

    // Update is called once per frame
    void Update()
    {
        if (!isTouchingLoick && rbB.bodyType != RigidbodyType2D.Dynamic) //Asegura que la caja empiece dinámica si no está tocando a Loick
        {
            rbB.bodyType = RigidbodyType2D.Dynamic; 
            rbB.gravityScale = 1;
            
        }
       else if (rbB.bodyType == RigidbodyType2D.Dynamic)
       {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, 10f);
            if (hit.collider != null)
            {
                rbB.linearVelocityX = 0;
                rbB.linearVelocityY = -5;
            }
       }// Si no está tocando a Loick, la caja cae
   
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Loick")) // Se convierte en estática solo cuando Loick la toca
        {
            rbB.bodyType = RigidbodyType2D.Static;
            isTouchingLoick = true;
            rbB.gravityScale = 0; // Desactiva la gravedad cuando es estática
        }
        else if (collision.gameObject.CompareTag("Louise"))
        {
            rbB.bodyType = RigidbodyType2D.Dynamic;
            isTouchingLoick = false;
            rbB.gravityScale = 1;
        }
        
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Louise"))
        {
            rbB.bodyType = RigidbodyType2D.Static;
            rbB.gravityScale = 1; // Reactiva la gravedad al salir del contacto
        }
    }
}
