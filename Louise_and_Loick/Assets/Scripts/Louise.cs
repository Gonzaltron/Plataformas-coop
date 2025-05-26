using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class Louise : MonoBehaviour
{
    bool andar = false;
    //Se acceden a los controles de movimiento 
    private InputAction MoveLouise;
    //Se inicializa la fuerza de salto
    [SerializeField] float jumpForce;
    //Se inicializa la velocidad de movimiento
    [SerializeField] float moveSpeed;
    private Rigidbody2D rb;

    //Controla la velocidad cuando toca o deja de tocar cajas
    float velocityWithoutBox;
    float velocityWhileBox;
    //Controla si se han subido a una plataforma móvil de raíl(Esto se utiliza en el script de PlataformaMovilRiel)
    public bool isMovingplatform;
    //Detecta si hay suelo
    public GameObject [] detectorground;
    //Detecta si hay techo
    public GameObject [] detectorTecho;
    //Controla si el personaje ha saltado o no
    bool jumpOn;
    private Animator animator; // Variable para usar al Animator
    private bool isOnLadder = false; // Variable para detectar si est� en la escalera
    private bool isTouchingBox = false; // Variable para detectar si est� tocando una caja


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        MoveLouise = InputSystem.actions.FindAction("MoveLouise");
        animator = GetComponent<Animator>(); // Obtener el Animator
        isMovingplatform = false;
        velocityWithoutBox = 7;
        velocityWhileBox = 5;
       
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.linearVelocityX != 0 && rb.linearVelocityY == 0)
        {
            if (andar == false)
            {
                andar = true;
                int numero = Random.Range(9, 16);
                Transform ChildMoove = this.transform.GetChild(numero);
                var AudioMoove = ChildMoove.GetComponent<AudioSource>();
                AudioMoove.Play();
                StartCoroutine(DelayAudio());
            }
        }
        Vector2 moveValue = MoveLouise.ReadValue<Vector2>();
        bool isMoving = Mathf.Abs(moveValue.x) > 0.1f;

        // Animaci�n de la escalera
        if (isOnLadder)
        {
            animator.SetBool("isWalkingRight", false); // La condicion de isWalkingRIght se vuelve false y hace que no se active la animacion de caminar a la derecha
            animator.SetBool("isWalkingLeft", false); // La condicion de isWalkingLeft se vuelve false y hace que no se active la animacion de caminar a la izquierda
            animator.SetBool("isPushingBox", false); // La condicion de isPushingBox se vuelve false y hace que no se active la animacion de empujar caja
            animator.SetBool("isOnLadder", true); // La condicion de IsOnLadder se vuelve true y hace que se active la animacion de la escalera
            return; 
        }
        else
        {
            animator.SetBool("isOnLadder", false); //  La condicion de IsOnLadder se vuelve false  y hace que no se active la animacion de la escalera
        }

        if (isTouchingBox)
        {
            animator.SetBool("isPushingBox", true); // La condicion de isPushingBox se vuelve true y hace que se active la animacion de empujar la caja
            animator.SetFloat("Speed", Mathf.Abs(moveValue.x));

            if (moveValue.x > 0)
            {
                animator.SetBool("isWalkingRight", true); // Se activa la condicion de caminar a la derecha, lo que combinado con el true de isPushingBox hace que se active la animacion de empujar a la derecha
                animator.SetBool("isWalkingLeft", false); // Se desactiva la condicion de caminar a la izquierda para asegurarse de que se active la animacion de empujar a la derecha
            }
            else if (moveValue.x < 0)
            {
                animator.SetBool("isWalkingRight", false);  // Se desactiva la condicion de caminar a la derecha  para asegurarse de que se active la animacion de empujar a la izquierda
                animator.SetBool("isWalkingLeft", true); // Se activa la condicion de caminar a la izquierda, lo que combinado con el true de isPushingBox hace que se active la animacion de empujar a la izquierda
            }
            else if (moveValue.x < 0)
            {
                animator.SetBool("isWalkingRight", false);
                animator.SetBool("isWalkingLeft", true);
            }
        }
        else
        {
            animator.SetBool("isPushingBox", false);
            animator.SetFloat("Speed", Mathf.Abs(moveValue.x));

            if (moveValue.x > 0)
            {
                animator.SetBool("isWalkingRight", true);
                animator.SetBool("isWalkingLeft", false);
            }
            else if (moveValue.x < 0)
            {
                animator.SetBool("isWalkingRight", false);  // Se desactiva la condicion de caminar a la derecha  para asegurarse de que se active la animacion de empujar a la izquierda
                animator.SetBool("isWalkingLeft", true); // Se activa la condicion de caminar a la izquierda, lo que combinado con el true de isPushingBox hace que se active la animacion de empujar a la izquierda
            }
            else
            {
                animator.SetBool("isWalkingRight", false);
                animator.SetBool("isWalkingLeft", false);
            }
        }
    }

       

    
    //Funcion para comprobar si tiene suelo
    private void CheckerGround()
    {
        // Para detectar si hay suelo, por cada objeto de detector de collision lanzará un rayo hacia abajo
        foreach (GameObject g in detectorground)
        {
            RaycastHit2D hit = Physics2D.Raycast(g.transform.position, -Vector2.up, 3);
            //Si alguno de los rayos encuentra algo y la distancia entre el rayo y el objeto es menor o igual a 0.3
            if (hit.collider != null)
            {
                if (hit.collider.gameObject.tag == "BigSpike" || hit.collider.gameObject.tag == "Tag 4 Spike")
                {
                    jumpOn = false;
                    break;
                }
                if (hit.distance <= 0.3)
                {
                    //Tendrá un pequeño delay de salto
                    StartCoroutine(DelaySalto());
                    //Activara la variable de permitir el salto 
                    jumpOn = true;

                    break;
                    
                }
                else
                {
                    //Si no se desactiva el salto
                    jumpOn = false;
                    
                }
            }
            //Si no se desactiva el salto
            else
            {
                jumpOn = false;
                
            }
        }
    }

    private void FixedUpdate()
    {
        //Se llama a la funcíon de detectar suelo
        CheckerGround();
        //Para detectar si hay techo, por cada objeto de detector de collision lanzará un rayo hacia arriba
        foreach (GameObject t in detectorTecho)
        {
            RaycastHit2D hitUP = Physics2D.Raycast(t.transform.position, Vector2.up, 3);
            //Si alguno de los rayos encuentra algo y la distancia entre el rayo y el objeto es menor o igual a 0.3
            if (hitUP.collider != null)
            {
                if (hitUP.distance <= 0.3)
                {
                    //Se desactiva la variable de salto para que no se pegue al techo
                    jumpOn = false;
                    break;
                }
            }
            //Si es mayor, comprueba si hay suelo
            else if (hitUP.distance >= 0.3)
            {
                CheckerGround();
            }
        }
            
        //Si se está presionando alguna de las teclas configuradas en project settings de Louise
        if (MoveLouise.IsPressed())
        {
            //Se le asigna a una variale el vector normalizado que esté leyendo de MoveLouise
            Vector2 moveValue = MoveLouise.ReadValue<Vector2>();
            rb.linearVelocity = new Vector2(moveValue.x * moveSpeed, rb.linearVelocityY);
           
        }
        if (Input.GetKeyUp(KeyCode.A) && jumpOn == true || Input.GetKeyUp(KeyCode.D) && jumpOn == true)
        {
            rb.linearVelocity = Vector2.zero;
        }
        //Si se presiona la tecla espacio y se activa la variable de salto
        if (Input.GetKey(KeyCode.W)  && jumpOn == true)
        {
            Transform Child = this.transform.GetChild(8);
            var saltoAudio = Child.GetComponent<AudioSource>();
            saltoAudio.Play();
            //Permite al jugador moverse mientras está en el aire y ha presionado el botón de salto
            rb.linearVelocity = new Vector2(rb.linearVelocityX, jumpForce);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Si colisiona contra un objeto con la tag de "Box"
        if (collision.gameObject.CompareTag("Box"))
        {
            isTouchingBox = true; // El personaje esta tocando una caja
            moveSpeed = velocityWhileBox; // La velocidad se le reduce a la mitad

        }
        // Si colisiona contra un objeto con la tag de "Ladder"
        if (collision.gameObject.CompareTag("Ladder"))
        {
            isOnLadder = true; // El personaje esta en la escalera
        }

     
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        // Si deja de colisionar con el objeto con la tag "Box"
        if (collision.gameObject.CompareTag("Box"))
        {
            // La velocidad vuelve a ser la original 
            moveSpeed = velocityWithoutBox;
            isTouchingBox = false;
            animator.SetBool("isPushingBox", false); // Desactivar animacion de empujar caja
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Si toca la escalera
        if (collision.gameObject.CompareTag("Ladder"))
        {
            isOnLadder = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        // Si deja de tocar la escalera
        if (collision.gameObject.CompareTag("Ladder"))
        {
            isOnLadder = false;
            animator.SetBool("isOnLadder", false); // Desactiva animacion de escalera
        }

    }

    IEnumerator DelayAudio()
    {
        yield return new WaitForSeconds(0.4f);
        andar = false;
    }
    //Hace un delay de 0.4 segundos entre salto
    IEnumerator DelaySalto()
    {
        yield return new WaitForSeconds(0.4f);
    }
}
