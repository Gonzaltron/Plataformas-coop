using UnityEngine;

public class DosInterruptoresUnapuerta : MonoBehaviour
{
    public bool activated;
    [SerializeField] public Transform Door;
    public Vector2 doorOff;
    public Vector2 doorOn;
    private Animator animator;


    public int contador;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>(); // Obtener el Animator
        activated = false;
        Door.transform.position = doorOff;
        contador = 0;
    }


    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay2D(Collider2D other)
    {
        animator.SetBool("activado", true);
        activated = true;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        contador++;
        if ((Vector2)Door.transform.position == doorOn)
        {
            Door.GetComponent<AudioSource>().Play();
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        animator.SetBool("activado", false);
        activated = false;
        contador--;
        Transform child = Door.GetChild(0);
        child.GetComponent<AudioSource>().Play();
    }
}
