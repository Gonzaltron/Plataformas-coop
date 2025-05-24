using UnityEngine;

public class SwitchPlatforms : MonoBehaviour
{
    public bool activated = false;
    public Vector3 positionOn; //Posicion en ON declarada
    public Vector3 positionOff; //posicion en Off declarada
    [SerializeField] public Transform Platform;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        activated = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Si el switch está activado, mueve la plataforma a la posición ON
        if (activated == true)
        {
            this.transform.position = positionOn;
            
        }
    }

    //Mientras se esté en el trigger, se activa el switch
    void OnTriggerStay2D(Collider2D other)
    {
        activated = true;
    }

    //al salir del trigger, se desactiva el switch y se mueve la plataforma a la posición OFF
    void OnTriggerExit2D(Collider2D other)
    {
        activated = false;
        this.transform.position = positionOff;
    }
}
