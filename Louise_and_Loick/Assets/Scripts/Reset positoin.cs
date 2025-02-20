using UnityEngine;

public class ResetPosition : MonoBehaviour
{
    
    public Vector3 resetPosition;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Box"))
        {
            transform.position = resetPosition;
        }
    }
}
