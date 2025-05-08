using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuOpciones : MonoBehaviour
{
    public GameObject ObjetoMenuPausa;
    public bool Pausa = false;

    void Start()
    {
        ObjetoMenuPausa.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (Pausa == false)
            {
                ObjetoMenuPausa.SetActive(true);
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
        ObjetoMenuPausa.SetActive(false);
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
        
    }
}
