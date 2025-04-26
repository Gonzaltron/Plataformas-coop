using UnityEngine;

public class Enemigo_Nivel4 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float speed;
    public bool moveRight;
    private Rigidbody2D rbE;
    // Update is called once per frame
    void FixedUpdate()
    {
        if (moveRight)
        {
            transform.Translate(2 * Time.deltaTime * speed, 0, 0);
        }
        else
        {
            transform.Translate(-2 * Time.deltaTime * speed, 0, 0);
        }
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, 10f);
        if (hit.collider != null)
        {
            rbE.linearVelocityX = 0;
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
}
