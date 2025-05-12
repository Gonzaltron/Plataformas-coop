using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuOpciones : MonoBehaviour
{

    public bool Pausa = false;

    void Start()
    {
    }
    void Update() 
    {
          if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Pausa == false)
            {
                SceneManager.LoadScene("MenuPausa",LoadSceneMode.Additive);
                Pausa = true;

                Time.timeScale = 0f; // Pausa el juego
                Cursor.visible =true; // Muestra el cursor
            }
            else
            {
                ResumeGame();
            }
        }
    }



    public void ResumeGame()
    {
        Time.timeScale = 1f; // Reanuda el juego
        Cursor.visible = false; // Oculta el cursor
        Pausa = false;
    }

    // Update is called once per frame
    public void QuitGame()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
