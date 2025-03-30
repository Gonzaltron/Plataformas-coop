using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Elevator : MonoBehaviour
{
    bool CheckerLouise = false;
    bool CheckerLoick = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (CheckerLouise == true && CheckerLoick == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    private void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.CompareTag("Louise"))
        {
            CheckerLouise = true;
        }
        else if (other.gameObject.CompareTag("Loick"))
        {
            CheckerLoick = true;
        }
    }
}
