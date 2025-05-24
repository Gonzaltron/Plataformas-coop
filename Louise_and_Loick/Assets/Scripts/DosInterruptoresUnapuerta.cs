using UnityEngine;

public class DosInterruptoresUnapuerta : MonoBehaviour
{
    public bool activated;
    [SerializeField] public Transform Door;
    public Vector2 doorOff;
    public Vector2 doorOn;
    private Animator animator; // Variable para usar el animator


    public int contador;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>(); // Obtener el Animator
        activated = false;
        Door.transform.position = doorOff; // Posición inicial de la puerta cerrada
        contador = 0;
    }


    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay2D(Collider2D other)
    {
        animator.SetBool("activado", true); // Se activa la animacion del boton cuando los personajes lo tocan
        activated = true;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        contador++;
        if ((Vector2)Door.transform.position == doorOn) //Si la puerta está abierta 
        {
            Door.GetComponent<AudioSource>().Play(); // Reproduce el sonido del objeto Door
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        animator.SetBool("activado", false); // Cuando los personajes dejan de tocar el boton la animacion se desactiva
        activated = false;
        contador--;
        Transform child = Door.GetChild(0);  // Obtiene el primer hijo del objeto Door
        child.GetComponent<AudioSource>().Play(); // Reproduce el sonido del hijo
    }
}
