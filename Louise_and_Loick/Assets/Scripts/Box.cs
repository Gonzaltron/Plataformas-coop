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
        //si la caja se mueve en x, pero no en y
        if (rbB.linearVelocity.x != 0 && rbC.linearVelocity.y == 0)
        {
            cajaAudio.mute = false; // quita el mute del sonido de la caja
        }
        else //sino
        {
            cajaAudio.mute = true; //activa el mute del sonido de la caja
        }

        //si la caja no toca a loick, y e rigidbody no es dinámico, lo convierte en dinámico
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
                    rbB.constraints = RigidbodyConstraints2D.None;             //hace que la caja se pueda mover, pero no rotar en z
                    rbB.constraints = RigidbodyConstraints2D.FreezeRotation;   //hace que la caja se pueda mover, pero no rotar en z
                    isAir = false;
                    break;
                }
                else
                {
                    isAir = true; //la caja esta en el aire
                    rbB.constraints = RigidbodyConstraints2D.FreezePositionX; //congela l aposicion en x
                    rbB.constraints = RigidbodyConstraints2D.FreezeRotation; //congela la rotacion en z

                }
            }
            else
            {
                isAir = true;
                rbB.constraints = RigidbodyConstraints2D.FreezePositionX;     //congela l aposicion en x
                rbB.constraints = RigidbodyConstraints2D.FreezeRotation;     //congela la rotacion en z

            }

        }
    }

    //al entrar en colision
    private void OnCollisionEnter2D(Collision2D collision)
    {

        //si la caja toca a loick, la masa se cambia
        if (collision.gameObject.CompareTag("Loick")) 
        {
            rbB.mass = 10000;
            isTouchingLoick = true;

        }
        //s toca a louise, la masa vueve a la normalidad
        else if (collision.gameObject.CompareTag("Louise"))
        {
            rbB.mass = originalMass;
            isTouchingLoick = false;
        }

    }

    //al salir de la colision
    private void OnCollisionExit2D(Collision2D collision)
    {
        //si sale louise, y está en el aire, so congela por un momento
        if (collision.gameObject.CompareTag("Louise") && isAir == true)
        {
            rbB.linearVelocity = Vector2.zero;
        }
    }

}
