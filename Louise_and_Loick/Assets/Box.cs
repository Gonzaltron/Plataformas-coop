using UnityEngine;

public class Box : MonoBehaviour
{
    private Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Loick"))
        {
            rb.bodyType = RigidbodyType2D.Static;
        }
        if (collision.gameObject.CompareTag("Louise"))
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Louise"))
        {
            rb.bodyType = RigidbodyType2D.Static;
        }
    }
}
