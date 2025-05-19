using UnityEngine;

public class BoxPushable : MonoBehaviour
{
    private Rigidbody2D rbB;
    public GameObject[] detectorground;
    private bool isTouchingLoick = false;
    float originalMass;
    bool isAir = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rbB = GetComponent<Rigidbody2D>();
        originalMass = rbB.mass; // La caja comienza como dinámica        
    }

    // Update is called once per frame
    void Update()
    {
        var cajaAudio = this.GetComponent<AudioSource>();
        var rbC = this.GetComponent<Rigidbody2D>();
        if (rbB.linearVelocity.x != 0 && rbC.linearVelocity.y == 0) // Si la caja se mueve en x
        {
            cajaAudio.mute = false;
        }
        else
        {
            cajaAudio.mute = true;
        }

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
                    isAir = false;
                    break;
                }
                else
                {
                    isAir = true;
                    rbB.constraints = RigidbodyConstraints2D.FreezePositionX;
                    rbB.constraints = RigidbodyConstraints2D.FreezeRotation;

                }
            }
            else
            {
                isAir = true;
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
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Louise") && isAir == true)
        {
            rbB.linearVelocity = Vector2.zero;
        }
    }

}
