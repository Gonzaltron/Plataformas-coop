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


}
