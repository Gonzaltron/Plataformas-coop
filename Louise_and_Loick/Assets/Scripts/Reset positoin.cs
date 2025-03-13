using UnityEngine;

public class ResetPosition : MonoBehaviour
{

    public Vector3 resetPosition;
    [SerializeField] private Transform P1;
    [SerializeField] private Transform P2;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Death"))
        {
            P1.transform.position = resetPosition;
            P2.transform.position = resetPosition;
        }

       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Checkpoint"))
        {
         resetPosition = collision.gameObject.transform.position;
        }
    }
}
