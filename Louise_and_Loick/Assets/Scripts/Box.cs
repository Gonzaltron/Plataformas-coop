using UnityEngine;

public class BoxPushable : MonoBehaviour
{
    private Rigidbody2D rbB;
    private bool isTouchingLoick = false;
    private float originalMass;
    [SerializeField] GameObject [] c;
    private bool allRaysNull;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rbB = GetComponent<Rigidbody2D>();
 
        rbB.bodyType = RigidbodyType2D.Dynamic; // La caja comienza como dinámica
        originalMass = rbB.mass;
    }

    // Update is called once per frame
    void Update()
    {
        allRaysNull = true;
        
        if (!isTouchingLoick && rbB.bodyType != RigidbodyType2D.Dynamic) //Asegura que la caja empiece dinámica si no está tocando a Loick
        {
            rbB.bodyType = RigidbodyType2D.Dynamic;
            rbB.gravityScale = 1;

        }
        foreach (GameObject g in c)
        {
            RaycastHit2D hit = Physics2D.Raycast(g.transform.position, -Vector2.up, 10f);
            Debug.DrawRay(g.transform.position, -Vector2.up, Color.yellow);

            if (hit.collider == null)
            {
                allRaysNull = false;
                break;
            }
        }
        if (allRaysNull)
        {
            rbB.linearVelocity = new Vector2(0, -7);
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Loick")) // Se convierte en estática solo cuando Loick la toca
        {
            rbB.mass = 10000000;
            isTouchingLoick = true;
        }
        else if (collision.gameObject.CompareTag("Louise"))
        {
            rbB.mass = originalMass;
            isTouchingLoick = false;
        }

    }
}
