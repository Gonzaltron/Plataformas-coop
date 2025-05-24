using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class Loick : MonoBehaviour
{
    bool andar = false;
    //Se acceden a los controles de movimiento 
    private InputAction MoveLoick;
    //Se inicializa la fuerza de salto
    [SerializeField] float jumpForce;
    //Se inicializa la velocidad de movimiento
    [SerializeField] float moveSpeed;
    private Rigidbody2D rb;
    private Animator animator; // Referencia al Animator

    //Controla si se han subido a una plataforma móvil de raíl(Esto se utiliza en el script de PlataformaMovilRiel) 
    public bool isMovingplatform;
    //Detecta si hay suelo
    public GameObject[] detectorground;
    //Detecta si hay techo
    public GameObject[] detectorTecho;
    //Controla si el personaje ha saltado o no
    bool jumpOn;

    private bool isOnLadder = false; // Variable para detectar si está en la escalera
    //Marca cual es la velocidad que queremos que llegue
    private Vector2 targetVelocity;
    //Marca el tiempo en el que decelera la velocidad del personaje
    private float deceleration = 10f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        MoveLoick = InputSystem.actions.FindAction("MoveLoick");
        animator = GetComponent<Animator>(); // Obtener el Animator
        isMovingplatform = false;
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
        // Obtener el valor de movimiento
        Vector2 moveValue = MoveLoick.ReadValue<Vector2>();
        bool isMoving = Mathf.Abs(moveValue.x) > 0.1f; // Verificar si se está moviendo

        // Si está en la escalera, mostrar la animación de espaldas
        if (isOnLadder)
        {
            animator.SetBool("isWalkingRight", false);  // Desactivar caminar hacia la derecha
            animator.SetBool("isWalkingLeft", false);   // Desactivar caminar hacia la izquierda
            animator.SetBool("isBackwards", true);      // Activar animación de espaldas
        }
        else
        {
            
            animator.SetFloat("Speed", Mathf.Abs(moveValue.x)); // Establecer la velocidad para las animaciones y caminar

            // Animaciones de caminar
            if (moveValue.x > 0)
            {
                animator.SetBool("isWalkingRight", true);  // Activar caminar a la derecha
                animator.SetBool("isWalkingLeft", false);  // Desactivar caminar a la izquierda
                animator.SetBool("isBackwards", false);    // Desactivar animación de espaldas
            }
            else if (moveValue.x < 0)
            {
                animator.SetBool("isWalkingRight", false); // Desactivar caminar a la derecha
                animator.SetBool("isWalkingLeft", true);   // Activar caminar a la izquierda
                animator.SetBool("isBackwards", false);    // Desactivar animación de espaldas
            }
            else
            {
                animator.SetBool("isWalkingRight", false); // Desactivar caminar a la derecha
                animator.SetBool("isWalkingLeft", false);  // Desactivar caminar a la izquierda
                animator.SetBool("isBackwards", false);    // Desactivar animación de espaldas
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
        //Si se está presionando alguna de las teclas configuradas en project settings de Loick
        if (MoveLoick.IsPressed())
        {
            //Se le asigna a una variale el vector normalizado que esté leyendo de MoveLoick
            Vector2 moveValue = MoveLoick.ReadValue<Vector2>().normalized;
            rb.linearVelocity = new Vector2(moveValue.x * moveSpeed, rb.linearVelocityY);
            
        }
        //Si se deja de presionar las teclas de movimiento el movimiento del personaje se para
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            rb.linearVelocity = Vector2.zero;
        }
        //Si se presiona la tecla espacio y se activa la variable de salto
        if (Input.GetKey(KeyCode.UpArrow) && jumpOn == true)
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
        if (collision.gameObject.CompareTag("Ladder"))
        {
            isOnLadder = true; // Loick está en la escalera
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Si colisiona contra un objeto con la tag de "Ladder"
        if (collision.gameObject.CompareTag("Ladder"))
        {
            isOnLadder = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        // Si colisiona contra un objeto con la tag de "Ladder"
        if (collision.gameObject.CompareTag("Ladder"))
        {
            isOnLadder = false;
            animator.SetBool("isBackwards", false);
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

