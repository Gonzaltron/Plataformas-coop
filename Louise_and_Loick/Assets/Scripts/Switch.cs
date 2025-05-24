using UnityEngine;
using System.Collections;

public class Switch : MonoBehaviour
{
    public bool activated;
    [SerializeField] public Transform Door; // Referencia al objeto de la puerta
    public Vector2 doorOff; // Posición de la puerta cuando está cerrada
    public Vector2 doorOn; // Posición de la puerta cuando está abierta
    private Animator animator;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>(); // Obtener el Animator
        activated = false; 
        doorOff = Door.transform.position;                            //establecer las posiciones del objeto
        doorOn = Door.transform.position + new Vector3(2000, 0, 0);   //establecer las posiciones del objeto
        
    }


    // Update is called once per frame
    void Update()
    {
        
        
    }

    //al entrar en el trigger, se activa la puerta y se reproduce el sonido
    private void OnTriggerEnter2D(Collider2D collision)
    {
        AudioPlay();
        DelayTime();
    }

    //al permanecer en el trigger, se activa la puerta
    void OnTriggerStay2D(Collider2D other)
    {
        activated = true;
        
        Door.transform.position = doorOn;
        animator.SetBool("activado", true);
        
    }

    //al salir del trigger, se desactiva la puerta y se reproduce el sonido
    void OnTriggerExit2D(Collider2D other)
    {
        activated = false;
        Door.transform.position = doorOff;
        animator.SetBool("activado", false);
        AudioPlay();
        DelayTime();
    }

    //para reporducir el sonido
    void AudioPlay()
    {
        //si la puerta esta activada
        if(activated == true)
        {
            //reproduce el sonido correspondiente
            Door.GetComponent<AudioSource>().Play();
            DelayTime();
        }

        //si la puerta esta desactivada
        else if (activated == false)
        {
            //reproduce el sonido correspondiente
            Transform child = Door.GetChild(0);
            child.GetComponent<AudioSource>().Play();
            DelayTime();
        }
    }

    IEnumerator DelayTime()
    {
        // Espera 0.5 segundos antes de continuar
        yield return new WaitForSeconds(0.5f);
    }
}
