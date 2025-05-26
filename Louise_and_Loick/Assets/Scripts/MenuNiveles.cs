using UnityEngine;

public class MenuNiveles : MonoBehaviour
{
    public void Nivel1()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Nivel_1");
    }
    public void Nivel2()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Nivel_2");
    }
    public void Nivel3()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Nivel_3");
    }
    public void Nivel4()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Nivel_4");
    }
    public void Nivel5()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Nivel_5");
    }
    public void Nivel6()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Nivel_6");
    }
    public void Nivel7()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Nivel_7");
    }
    public void Back()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MenuPrincipal");
    }

}
