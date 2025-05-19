using UnityEngine;

public class Agua : MonoBehaviour
{
    public Cubodeaguaboton cubodeaguaboton;
    private Animator animator;


    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Solo activa la animaci�n si el agua est� activada por el bot�n
        if (/*cubodeaguaboton.IsAguaOn() && */!animator.GetBool("Activado"))
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

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("Ground"))
        {
            var aguaAudio = GetComponent<AudioSource>();
            aguaAudio.Play();
        }
    }
}
