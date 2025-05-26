using UnityEngine;

public class MenuNiveles : MonoBehaviour
{
    public void Nivel1()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Nivel_1");
        Time.timeScale = 1; //Asegura que el tiempo del juego se reanude al iniciar un nuevo nivel
    }
    public void Nivel2()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Nivel_2");
        Time.timeScale = 1; //Asegura que el tiempo del juego se reanude al iniciar un nuevo nivel
    }
    public void Nivel3()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Nivel_3");
        Time.timeScale = 1; //Asegura que el tiempo del juego se reanude al iniciar un nuevo nivel
    }
    public void Nivel4()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Nivel_4");
        Time.timeScale = 1; //Asegura que el tiempo del juego se reanude al iniciar un nuevo nivel
    }
    public void Nivel5()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Nivel_5");
        Time.timeScale = 1; //Asegura que el tiempo del juego se reanude al iniciar un nuevo nivel
    }
    public void Nivel6()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Nivel_6");
        Time.timeScale = 1; //Asegura que el tiempo del juego se reanude al iniciar un nuevo nivel
    }
    public void Nivel7()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Nivel_7");
        Time.timeScale = 1; //Asegura que el tiempo del juego se reanude al iniciar un nuevo nivel
    }
    public void Back()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MenuPrincipal");
    }

}
