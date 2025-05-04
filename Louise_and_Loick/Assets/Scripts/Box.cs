using UnityEngine;

public class BoxPushable : MonoBehaviour
{
    private Rigidbody2D rbB;
    private bool isTouchingLoick = false;
    private float originalMass;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rbB = GetComponent<Rigidbody2D>();
        rbB.gravityScale = 1; // Asegura que la gravedad est� activada
        rbB.bodyType = RigidbodyType2D.Dynamic; // La caja comienza como din�mica
        originalMass = rbB.mass;
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
        if (hit.collider != null)
        {
            rbB.linearVelocityX = 0;
            rbB.linearVelocityY = -5;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Loick")) // Se convierte en est�tica solo cuando Loick la toca
        {
            rbB.mass = 10000000;
            isTouchingLoick = true;
            rbB.gravityScale = 0; // Desactiva la gravedad cuando es est�tica
        }
        else if (collision.gameObject.CompareTag("Louise"))
        {
            rbB.mass = originalMass;
            isTouchingLoick = false;
            rbB.gravityScale = 1;
        }
        
    }
}
