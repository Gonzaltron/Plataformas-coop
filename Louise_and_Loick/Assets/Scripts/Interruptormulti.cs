using UnityEngine;

public class Interruptormulti : MonoBehaviour
{
    //Este interruptor solo se coloca cuando se necesitan abrir más de una puerta. Funciona como los interruptores normales.
    public bool activated;
    [SerializeField] public Transform Door;
    public Vector2 doorOff;
    public Vector2 doorOn;
    [SerializeField] public Transform Door2;
    public Vector2 doorOff2;
    public Vector2 doorOn2;
    [SerializeField] public Transform Door3;
    public Vector2 doorOff3;
    public Vector2 doorOn3;
    private Animator animator; // Variable para usar el animator 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>(); // Obtener el Animator
        activated = false;
        Door.transform.position = doorOff;
        Door2.transform.position = doorOff2;
        Door3.transform.position = doorOff3;
        doorOff = Door.transform.position;
        doorOff2 = Door2.transform.position;
        doorOff3 = Door3.transform.position;
        doorOn = Door.transform.position + new Vector3(2000, 0, 0);
        doorOn2 = Door2.transform.position + new Vector3(2000, 0, 0);
        doorOn3 = Door3.transform.position + new Vector3(2000, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    void OnTriggerStay2D(Collider2D other)
    {
        animator.SetBool("activado", true); //Cuando se toca el boton, la condicion del parametro activado se vuelve true y activa la animacion
        activated = true;
        Door.transform.position = doorOn;
        Door2.transform.position = doorOn2;
        Door3.transform.position = doorOn3;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        animator.SetBool("activado", false); // Cuando se deja de tocar el boton, la animacion se desactiva
        activated = false;
        Door.transform.position = doorOff;
        Door2.transform.position = doorOff2;
        Door3.transform.position = doorOff3;

    }
}
