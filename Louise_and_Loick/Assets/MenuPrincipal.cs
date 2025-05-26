using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    public void PlayGame()
    {
       SceneManager.LoadScene("Nivel_1");
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
