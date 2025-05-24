using UnityEngine;
using System.Collections;

public class Valve : MonoBehaviour
{
    public bool activated;
    public Vector2 ON;     //Posiciones del vapor
    public Vector2 OFF;    //Posiciones del vapor
    bool ONcheck; //Para compobar si loick esta en el trigger
    [SerializeField] public Transform Steam;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        activated = false;   //inicializa los favores a false
        ONcheck = false;     //inicializa los favores a false
        ON = Steam.transform.position + new Vector3(0, 2000, 0);  //establece los valores de On y Off
        OFF = Steam.transform.position;                           //establece los valores de On y Off
        Steam.transform.position = OFF; //coloca Steam en Off
    }


    // Update is called once per frame
    void Update()
    {
        // Si el jugador Loick esta en el trigger y presiona la tecla E, se activa o desactiva el vapor
        StartCoroutine(DelayTime()); // Espera 0.3 segundos antes de cambiar el estado del audio
        if (activated == true && Input.GetKeyDown(KeyCode.E))
        {
            if (ONcheck == true)
            {
                Steam.transform.position = OFF;

                activated = false;
            }
            else if (ONcheck == false)
            {
                Steam.transform.position = ON;

                activated = false;
            }
            activated = false;
            // Espera 0.5 segundos
            StartCoroutine(DelayTime2());
            // Cambia el estado de ONcheck para alternar entre activado y desactivado
            if (ONcheck == true)
            {
                ONcheck = false;
            }
            else if (ONcheck == false)
            {
                ONcheck = true;
            }
            // Espera 30 frames antes de permitir otra activaci��n
            StartCoroutine(WaitForFrames(30));
        }

    }

    //Al entrar en el trigger
    void OnTriggerEnter2D(Collider2D other)
    {
        // Si el objeto que entra en el trigger es Loick, activa el check del vapor
        if (other.CompareTag("Loick"))
        {
            activated = true;
        }
        if (other.CompareTag("Louise"))
        {
            activated = false;
        }
    }

    // Al permanecer en el trigger
    void OnTriggerStay2D(Collider2D other)
    {
        // Si el objeto que permanece en el trigger es Loick, activa el check del vapor
        if (other.CompareTag("Loick"))
        {
            activated = true;
        }
        if (other.CompareTag("Louise"))
        {
            activated = false;
        }
    }

    // Al salir del trigger
    void OnTriggerExit2D(Collider2D other)
    {
        // Si el objeto que sale del trigger es Loick, desactiva el check del vapor
        if (other.CompareTag("Loick"))
        {
            activated = false;
        }

    }

    IEnumerator DelayTime()
    {
        //espera 0.3 segundos antes de cambiar el estado del audio
        yield return new WaitForSeconds(0.3f);
        var audioSource = Steam.GetComponent<AudioSource>(); // Obtiene el componente AudioSource del objeto Steam
        // Si ONcheck es verdadero, silencia el audio. si es falso, lo desilencia
        if (ONcheck == true)
        {
            audioSource.mute = true;
        }
        else if (ONcheck == false)
        {
            audioSource.mute = false;
        }
    }


    IEnumerator DelayTime2()
    {
        // Espera 0.5 segundos 
        yield return new WaitForSeconds(0.5f);
    }

    IEnumerator WaitForFrames(int frames)
    {
        //espera 30 frames
        for (int i = 0; i < frames; i++)
        {
            yield return null; 
        }
    }
    // Comprueba si el vapor esta activado
    public bool IsVaporOn()
    {
        return ONcheck;
    }

}
