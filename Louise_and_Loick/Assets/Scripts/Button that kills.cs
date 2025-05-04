using UnityEngine;

public class Buttonthatkills : MonoBehaviour
{
    public Vector2 positionOn;
    public Vector2 positionOff;
    [SerializeField] public Transform P1;
    [SerializeField] public Transform P2;
    public Vector3 resetLouise;
    public Vector3 resetLoick;
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
            resetLouise = resetPositionLouise.resetPositionLouise;
            resetLoick = resetPositionLoick.resetPositionLoick;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Loick") || other.CompareTag("Louise"))
        {
            animator.SetBool("activado", true);
            P1.transform.position = resetLouise;
            P2.transform.position = resetLoick;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        animator.SetBool("activado", false);
    }
}


