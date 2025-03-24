using UnityEngine;

public class BoxPushable : MonoBehaviour
{
    private Rigidbody2D rbB;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rbB = GetComponent<Rigidbody2D>();
        rbB.gravityScale = 1;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Loick"))
        {
            rbB.bodyType = RigidbodyType2D.Static;
        }
        if (collision.gameObject.CompareTag("Louise"))
        {
            rbB.bodyType = RigidbodyType2D.Dynamic;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if  (collision.gameObject.CompareTag("Louise"))
        {
            rbB.bodyType = RigidbodyType2D.Static;
        }
    }
}
