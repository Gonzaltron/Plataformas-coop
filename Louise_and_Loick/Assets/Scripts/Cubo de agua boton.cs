using UnityEngine;
using System.Collections;

public class Cubodeaguaboton : MonoBehaviour
{
    bool SonidoAgua = false;
    public Vector2 aguaOrigen; // Posición inicial del agua
    public Vector2 aguaDestino; // Posición final del agua
    [SerializeField] public Transform agua;
    public float delay; // Tiempo de espera antes de reestablecer el agua
    public float speed; //velocidd de movimiento del agua
    Animator animator; // Variable para usar el animator
    bool contact = false;

    public bool animacionActiva = false;
    public float delayTime = 3f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>(); // Obtener el animator
        agua.position = aguaOrigen; // Inicializa la posición del agua
        contact = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Solo inicia la animación si no está ya activada
        if (contact && !animacionActiva)
        {
            StartCoroutine(DelayTime()); //llama a delaytime
            animacionActiva = true; // Evita que la animación se inicie varias veces
        }

        //si el agua esta en el destino
        if((Vector2)agua.transform.position == aguaDestino)
        {
            //si el sonido del agua no se ha reproducido
            if(SonidoAgua == false)
            {
                //lo reproduce
                SonidoAgua = true;
                StartCoroutine(aguasonido()); //llama a Sonidoagua
            }
        }
    }


    //al entrar en el trigger
    void OnTriggerEnter2D(Collider2D other)
    {
        //si es louise o Loick
        if (other.CompareTag("Louise") || other.CompareTag("Loick"))
        {
            animator.SetBool("activado",true); // Al tocar el boton la animacion del cubo de agua se activa
            agua.position = aguaOrigen;
            contact = true;  // Activa la animación al entrar en el trigger
        }
    }

    IEnumerator DelayTime()
    {

        // Mueve el agua hacia el destino
        while (Vector2.Distance(agua.position, aguaDestino) > 0.1f)
        {
            agua.position = Vector2.MoveTowards(agua.position, aguaDestino, speed * Time.deltaTime); //mueve el agua
            yield return null; // Espera antes de continuar
        }
        // Vuelve el agua a su posición original
        agua.position = aguaOrigen;
        // Desactiva la animación de agua
        animacionActiva = false;
        contact = false;

    }

    // Al salir del trigger
    private void OnTriggerExit2D(Collider2D other)
    {
        // Si Louise o Loick dejan de tocar el boton no se vuelve a activar la animacion
        if (other.CompareTag("Louise") || other.CompareTag("Loick"))
        {

            animator.SetBool("activado", false); 
            contact = false;
        }
    }

    // Devuelve el etsado del agua
    public bool IsAguaOn()
    {
        return contact;

    }

    IEnumerator aguasonido()
    {
        //toms el audio del agua
        var aguaAudio = GetComponent<AudioSource>();
        aguaAudio.Play(); //lo reproduce
        yield return new WaitForSeconds(10.0f); //espera
        aguaAudio.Stop(); //lo para
        SonidoAgua = false; // el audio de agua se desactiva
    }
}
