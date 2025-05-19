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
        // Solo activa la animación si el agua está activada por el botón
        if (/*cubodeaguaboton.IsAguaOn() && */!animator.GetBool("Activado"))
        {
            animator.SetBool("Activado", true);
        }
    }

    // llama al Animation event
    public void ResetAnimacion()
    {
        // Apaga el parámetro "Activado" para detener las animaciones
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
