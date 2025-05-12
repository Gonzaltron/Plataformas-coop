using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuOpciones : MonoBehaviour
{

    public bool Pausa = false;
    public string escenaActual;

    void Start()
    {
    }
    void Update() 
    {
          if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Pausa == false)
            {
                escenaActual = SceneManager.GetActiveScene().name; // Guarda la escena actual
                Pausar();
            }
            else
            {
                ResumeGame();
            }
        }
    }

    public void Pausar()
    {
        SceneManager.LoadScene("MenuPausa", LoadSceneMode.Additive);
        Pausa = true;
        Time.timeScale = 0f; // Pausa el juego
        Cursor.visible = true; // Muestra el cursor
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f; // Reanuda el juego
        Cursor.visible = false; // Oculta el cursor
        Pausa = false;
        SceneManager.UnloadSceneAsync("MenuPausa"); // Cierra el menú de pausa
    }

    // Update is called once per frame
    public void QuitGame()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }
    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
