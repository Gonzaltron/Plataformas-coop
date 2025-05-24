using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Elevator : MonoBehaviour
{
    private Animator animator;
    bool CheckerLouise = false;     //se declaran los check para cada personaje y se ponen en false
    bool CheckerLoick = false;      //se declaran los check para cada personaje y se ponen en false
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Si los dos personajes están en el ascensor, se inicia la corutina para cambiar de escena
        if (CheckerLouise == true && CheckerLoick == true)
        {
            StartCoroutine(DelayAction(1.0f));
            
        }
    }

    private void OnTriggerEnter2D (Collider2D other)
    {
        //cuando entraun personaje en el trigger, su check se activa
        if (other.gameObject.CompareTag("Louise"))
        {
            StartCoroutine(DelayAction(1.0f));
            Debug.Log("Trigger Louise");
            CheckerLouise = true;
            animator.SetBool("enAscensor",true);
        }
        else if (other.gameObject.CompareTag("Loick"))
        {
            StartCoroutine(DelayAction(1.0f));
            CheckerLoick = true;
            animator.SetBool("enAscensor", true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {

        //si alguno de los dos personajes sale del trigger, su check se desactiva
        if (other.gameObject.CompareTag("Louise"))
        {
            CheckerLouise = false;
            animator.SetBool("enAscensor", false);
        }

        else if (other.gameObject.CompareTag("Loick"))
        {
            CheckerLoick = false;
            animator.SetBool("enAscensor", false);
        }
    }

    IEnumerator DelayAction(float delay)
    {
        Debug.Log("llamada");
        //espera 1s 
        yield return new WaitForSeconds(delay);
        //Si los dos personajes están en el ascensor, se cambia de escena
        if (CheckerLouise == true && CheckerLoick == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
