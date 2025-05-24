using UnityEngine;

public class Agua : MonoBehaviour
{
    public Cubodeaguaboton cubodeaguaboton;
    private Animator animator; // Variable para usar el animator


    void Start()
    {
        animator = GetComponent<Animator>(); // Obtener el Animator
    }

    void Update()
    {
        // Solo activa la animaci�n si el agua est� activada por el bot�n
        if (cubodeaguaboton.IsAguaOn() && !animator.GetBool("Activado"))
        {
            animator.SetBool("Activado", true);
        }
    }

    // llama al Animation event
    public void ResetAnimacion()
    {
        // Apaga el par�metro "Activado" para detener las animaciones
        animator.SetBool("Activado", false);
    }

    //al entrar en colision
    void OnCollisionEnter2D(Collision2D other)
    {
        //si toca a enemy
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject); //destruye enemy
        }

        //si toca ground
        else if (other.gameObject.CompareTag("Ground"))
        {
            var aguaAudio = GetComponent<AudioSource>(); // Obtiene el componente AudioSource del objeto Agua
            aguaAudio.Play(); //reproduce el sonido de agua
        }
    }
}
