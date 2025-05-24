using UnityEngine;

public class Vapor : MonoBehaviour
{
    public Valve valve;
    private Animator animator; // Vaariable para usar el animator

    void Start()
    {
        animator = GetComponent<Animator>(); // Obtener el animator
    }

    void Update()
    {
        if (valve.IsVaporOn())
        {
            animator.SetBool("Activado", false); // Se cambia el estado del parametro a false y no activa ninguna animacion
        }
        else
        {
            animator.SetBool("Activado", true); // Se activa la animacion del vapor al volver al activar el vapor
        }
    }
}
