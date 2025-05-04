using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Elevator : MonoBehaviour
{
    private Animator animator;
    bool CheckerLouise = false;
    bool CheckerLoick = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CheckerLouise == true && CheckerLoick == true)
        {
            StartCoroutine(DelayAction(1.0f));
            
        }
    }

    private void OnTriggerEnter2D (Collider2D other)
    {
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
        yield return new WaitForSeconds(delay);
        if (CheckerLouise == true && CheckerLoick == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
