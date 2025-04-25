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
    public Vector3 position;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agua.position = aguaOrigen;
        contact = false;
        position = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (contact == true)
        {
            StartCoroutine(DelayTime());
            contact = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Louise") || other.CompareTag("Loick"))
        {
            contact = true;
            position = position - new Vector3(0, 0.5f, 0);
            this.transform.position = position;
        }
    }

    IEnumerator DelayTime()
    {
        Debug.Log("Iniciando movimiento del agua");

        // Mueve el agua gradualmente hacia el destino
        while (Vector2.Distance(agua.position, aguaDestino) > 0.1f)
        {
            agua.position = Vector2.MoveTowards(agua.position, aguaDestino, speed * Time.deltaTime);
            yield return null; // Espera un frame antes de continuar
        }


        yield return new WaitForSeconds(delay);


        agua.position = aguaOrigen;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Louise") || other.CompareTag("Loick"))
        {
            contact = false;
            position = position + new Vector3(0, 0.5f, 0);
            this.transform.position = position;
        }
    }
}
