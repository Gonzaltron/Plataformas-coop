using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Louise : MonoBehaviour
{
    private InputAction MoveLouise;
    [SerializeField] float jumpForce;
    [SerializeField] float moveSpeed;
    private Rigidbody2D rb;

    float velocityWithoutBox;
    float velocityWhileBox;
    public bool isMovingplatform;
    public GameObject [] detectorground;
    public GameObject [] detectorTecho;
    bool jumpOn;
    private Animator animator; // Referencia al Animator
    private bool isOnLadder = false; // Variable para detectar si está en la escalera
    private bool isTouchingBox = false; // Variable para detectar si está tocando una caja
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        MoveLouise = InputSystem.actions.FindAction("MoveLouise");
        animator = GetComponent<Animator>(); // Obtener el Animator
        jumpOn = false;
        isMovingplatform = false;
        velocityWithoutBox = 9;
        velocityWhileBox = velocityWithoutBox/2;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveValue = MoveLouise.ReadValue<Vector2>();
        bool isMoving = Mathf.Abs(moveValue.x) > 0.1f;

        // Animación de la escalera
        if (isOnLadder)
        {
            animator.SetBool("isWalkingRight", false);
            animator.SetBool("isWalkingLeft", false);
            animator.SetBool("isPushingBox", false); 
            animator.SetBool("isOnLadder", true);
            return; 
        }
        else
        {
            animator.SetBool("isOnLadder", false); 
        }

        if (isTouchingBox && isMoving)
        {
            animator.SetBool("isPushingBox", true);

            if (moveValue.x > 0)
            {
                animator.SetBool("isWalkingRight", true);
                animator.SetBool("isWalkingLeft", false);
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

            
            if (moveValue.x > 0)
            {
                animator.SetBool("isWalkingRight", true);
                animator.SetBool("isWalkingLeft", false);
            }
            else if (moveValue.x < 0)
            {
                animator.SetBool("isWalkingRight", false);
                animator.SetBool("isWalkingLeft", true);
            }
            else
            {
                animator.SetBool("isWalkingRight", false);
                animator.SetBool("isWalkingLeft", false);
            }
        }

        animator.SetFloat("Speed", Mathf.Abs(moveValue.x));

    }

    private void CheckerGround()
    {
        foreach (GameObject g in detectorground)
        {
            RaycastHit2D hit = Physics2D.Raycast(g.transform.position, -Vector2.up, 3);
            if (hit.collider != null)
            {
                if (hit.distance <= 0.3)
                {
                    jumpOn = true;
                    
                }
                else
                {
                    jumpOn = false;
                    
                }
            }
            else
            {
                jumpOn = false;
                
            }
        }
    }

    private void FixedUpdate()
    {
        CheckerGround();
        foreach (GameObject t in detectorTecho)
        {
            RaycastHit2D hitUP = Physics2D.Raycast(t.transform.position, Vector2.up, 3);
            if (hitUP.collider != null)
            {
                if (hitUP.distance <= 0.3)
                {
                    jumpOn = false;
                }
            }
            else if (hitUP.distance >= 0.3)
            {
                CheckerGround();
            }
        }
            

        if (MoveLouise.IsPressed())
        {
            Vector2 moveValue = MoveLouise.ReadValue<Vector2>();
            rb.linearVelocity = new Vector2(moveValue.x * moveSpeed, rb.linearVelocityY);
        }
        if (Input.GetKey(KeyCode.Space)  && jumpOn == true)
        {
            Transform Child = this.transform.GetChild(8);
            var saltoAudio = Child.GetComponent<AudioSource>();
            saltoAudio.Play();
            rb.linearVelocity = new Vector2(rb.linearVelocityX, jumpForce);
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Box"))
        {
            isTouchingBox = true; // El personaje está tocando una caja
            moveSpeed = velocityWhileBox;

        }
        if (collision.gameObject.CompareTag("Ladder"))
        {
            isOnLadder = true; // El personaje está en la escalera
        }
     
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Box"))
        {
            moveSpeed = velocityWithoutBox;
            isTouchingBox = false;
            animator.SetBool("isPushingBox", false); // Desactivar animación de empujar caja
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ladder"))
        {
            isOnLadder = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ladder"))
        {
            isOnLadder = false;
            animator.SetBool("isBackwards", false);
        }
  
    }
}
