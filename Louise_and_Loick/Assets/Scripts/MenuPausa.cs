using UnityEngine;
using UnityEngine.SceneManagement;

public class NewMonoBehaviourScript : MonoBehaviour

{

    public GameObject ObjetoMenuPausa;
    public bool Pausa = false;
    void Start()
    {
        DontDestroyOnLoad(ObjetoMenuPausa);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            if (Pausa == false)
            {
                Pausa = true;
                ObjetoMenuPausa.SetActive(true);
                Time.timeScale = 0f; // Pausa el juego
                Cursor.visible = true; // Muestra el cursor

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

    public void QuitGame()
    {
        Application.Quit();
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}