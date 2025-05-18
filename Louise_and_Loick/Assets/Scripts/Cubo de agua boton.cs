using UnityEngine;
using System.Collections;

public class Cubodeaguaboton : MonoBehaviour
{
    private Animator animator;
    public Vector2 aguaOrigen;
    public Vector2 aguaDestino;
    [SerializeField] public Transform agua;
    public float delay;
    public float speed;
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
        // Solo inicia la animaci�n si no est� ya activada
        if (contact && !animacionActiva)
        {
            StartCoroutine(DelayTime());
            animacionActiva = true; // Evita que la animaci�n se inicie varias veces
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Louise") || other.CompareTag("Loick"))
        {
            animator.SetBool("activado",true);
            agua.position = aguaOrigen;
            contact = true;  // Activa la animaci�n al entrar en el trigger
        }
    }

    IEnumerator DelayTime()
    {

        // Mueve el agua hacia el destino
        while (Vector2.Distance(agua.position, aguaDestino) > 0.1f)
        {
            agua.position = Vector2.MoveTowards(agua.position, aguaDestino, speed * Time.deltaTime);
            yield return null; // Espera un frame antes de continuar
        }
        // Vuelve el agua a su posici�n original
        agua.position = aguaOrigen;
        // Desactiva la animaci�n de agua
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
}
