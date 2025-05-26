using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    public void PlayGame()
    {
       SceneManager.LoadScene("Nivel_1");
        Time.timeScale = 1; //Asegura que el tiempo del juego se reanude al iniciar un nuevo nivel
    }
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }
    public void Back()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }
    public void Selector_Niveles()
    {
        SceneManager.LoadScene("MenuNiveles");
    }


}
