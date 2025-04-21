using UnityEngine;

public class Buttonthatkills : MonoBehaviour
{
    public Vector2 positionOn;
    public Vector2 positionOff;
    [SerializeField] public Transform P1;
    [SerializeField] public Transform P2;
    public Vector3 reset;
    public ResetPositionLouise resetPosition; //leaave empty
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        resetPosition = P1.GetComponent<ResetPositionLouise>(); //Toma el componente ResetPosition del objeto P1
        if (resetPosition == null)
        {
            Debug.LogError("ResetPosition component not found on P1");
        }
        else
        {
            reset = resetPosition.resetPosition; //Toma la posicion de reseteo del objeto P1
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (resetPosition == null)
        {
            Debug.LogError("ResetPosition component not found on P1");
        }
        else
        {
            reset = resetPosition.resetPosition;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Loick") || other.CompareTag("Louise"))
        {
            P1.transform.position = reset;
            P2.transform.position = reset;
        }
    }
}


