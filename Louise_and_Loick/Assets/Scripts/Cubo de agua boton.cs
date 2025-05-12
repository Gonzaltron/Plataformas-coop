using UnityEngine;
using System.Collections;

public class Cubodeaguaboton : MonoBehaviour
{
    public Vector2 aguaOrigen;
    public Vector2 aguaDestino;
    [SerializeField] public Transform agua;
    public float delay;
    public float speed;
    bool contact = false;

    public bool animacionActiva = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
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
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Louise") || other.CompareTag("Loick"))
        {
            contact = true;  // Activa la animación al entrar en el trigger
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

        yield return new WaitForSeconds(delay);

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
            contact = false;
        }
    }

    // Devuelve el etsado del agua
    public bool IsAguaOn()
    {
        return contact;
    }
}
