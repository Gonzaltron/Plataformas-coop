using UnityEngine;

public class Buttonthatkills : MonoBehaviour
{
    public Vector2 positionOn;  //esto no es necesario
    public Vector2 positionOff; //esto no es necesario
    [SerializeField] public Transform P1;   //Transform para el personaje
    [SerializeField] public Transform P2;   //Transform para el personaje
    public Vector3 resetLouise;  //posicion de reseteo para cada prsonaje
    public Vector3 resetLoick;   //posicion de reseteo para cada prsonaje
    public ResetPositionLouise resetPositionLouise; //leaave empty
    public ResetPosition resetPositionLoick; //leaave empty
    private Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>(); // Obtener el Animator
        resetPositionLouise = P1.GetComponent<ResetPositionLouise>(); //Toma el componente ResetPosition del objeto P1
        resetPositionLoick = P2.GetComponent<ResetPosition>(); //Toma el componente ResetPosition del objeto P2
        if (resetPositionLouise == null)
        {
            Debug.LogError("ResetPosition component not found on P1");
        }
        else
        {
            resetLouise = resetPositionLouise.resetPositionLouise; //Toma la posicion de reseteo del objeto P1
            resetLoick = resetPositionLoick.resetPositionLoick; //Toma la posicion de reseteo del objeto P2
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (resetPositionLouise == null)
        {
            Debug.LogError("ResetPosition component not found on P1");
        }
        else
        {
            resetLouise = resetPositionLouise.resetPositionLouise; //establece la posicion de reseteo a la variable de la opsicion de reseteo de los script de los personajes
            resetLoick = resetPositionLoick.resetPositionLoick;    //establece la posicion de reseteo a la variable de la opsicion de reseteo de los script de los personajes
        }
    }

    //al entrar en el trigger
    void OnTriggerEnter2D(Collider2D other)
    {
        //si lo otro es Loick o Louise
        if (other.CompareTag("Loick") || other.CompareTag("Louise"))
        {
            animator.SetBool("activado", true);
            P1.transform.position = resetLouise;  //envia a los personajes a su posicion de reseteo
            P2.transform.position = resetLoick;   //envia a los personajes a su posicion de reseteo
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        animator.SetBool("activado", false);
    }
}


