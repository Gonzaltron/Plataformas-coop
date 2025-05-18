using UnityEngine;

public class BoxPushable : MonoBehaviour
{
    private Rigidbody2D rbB;
    public GameObject[] detectorground;
    private bool isTouchingLoick = false;
    float originalMass;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rbB = GetComponent<Rigidbody2D>();
        rbB.gravityScale = 1; // Asegura que la gravedad esté activada
        originalMass = rbB.mass; // La caja comienza como dinámica
    }

    // Update is called once per frame
    void Update()
    {
        if (!isTouchingLoick && rbB.bodyType != RigidbodyType2D.Dynamic) //Asegura que la caja empiece dinámica si no está tocando a Loick
        {
            rbB.bodyType = RigidbodyType2D.Dynamic;

        }
        foreach (GameObject g in detectorground)
        {
            RaycastHit2D hit = Physics2D.Raycast(g.transform.position, -Vector2.up, 3);
            if (hit.collider != null)
            {
                if (hit.distance <= 0.3)
                {
                    rbB.constraints = RigidbodyConstraints2D.None;
                    rbB.constraints = RigidbodyConstraints2D.FreezeRotation;
                    break;
                }
                else
                {
                    rbB.constraints = RigidbodyConstraints2D.FreezePositionX;
                    rbB.constraints = RigidbodyConstraints2D.FreezeRotation;

                }
            }
            else
            {
                rbB.constraints = RigidbodyConstraints2D.FreezePositionX;
                rbB.constraints = RigidbodyConstraints2D.FreezeRotation;

            }
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {


        if (collision.gameObject.CompareTag("Loick")) // Se convierte en estática solo cuando Loick la toca
        {
            rbB.mass = 10000;
            isTouchingLoick = true;
        }
        else if (collision.gameObject.CompareTag("Louise"))
        {
            rbB.mass = originalMass;
            isTouchingLoick = false;
        }


    }
}
