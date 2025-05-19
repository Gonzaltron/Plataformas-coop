using UnityEngine;
using System.Collections;

public class Cubodeaguaboton : MonoBehaviour
{
    bool SonidoAgua = false;
    public Vector2 aguaOrigen;
    public Vector2 aguaDestino;
    [SerializeField] public Transform agua;
    public float delay;
    public float speed;
    Animator animator;
    bool contact = false;

    public bool animacionActiva = false;
    public float delayTime = 3f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        agua.position = aguaOrigen;
        contact = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Solo inicia la animación si no está ya activada
        if (contact && !animacionActiva)
        {
            StartCoroutine(DelayTime());
            animacionActiva = true; // Evita que la animación se inicie varias veces
        }
        if((Vector2)agua.transform.position == aguaDestino)
        {
            if(SonidoAgua == false)
            {
                SonidoAgua = true;
                StartCoroutine(aguasonido());
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Louise") || other.CompareTag("Loick"))
        {
            animator.SetBool("activado",true);
            agua.transform.position = Vector2.MoveTowards(agua.transform.position, aguaDestino, speed * Time.deltaTime);
            contact = true;  // Activa la animación al entrar en el trigger
        }
    }

    IEnumerator DelayTime()
    {

        // Mueve el agua hacia el destino
        while (Vector2.Distance(agua.position, aguaDestino) > 0.1f)
        {
            agua.position = Vector2.MoveTowards(agua.position, aguaDestino, speed * Time.deltaTime);
            yield return new WaitForSeconds(delay); // Espera antes de continuar
        }
        // Vuelve el agua a su posición original
        agua.position = aguaOrigen;
        // Desactiva la animación de agua
        animacionActiva = false;
        contact = false;

    }

    private void OnTriggerExit2D(Collider2D other)
    {
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
        var aguaAudio = GetComponent<AudioSource>();
        aguaAudio.Play();
        yield return new WaitForSeconds(10.0f);
        aguaAudio.Stop();
        SonidoAgua = false;
    }
}
