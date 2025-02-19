using UnityEngine;

public class ResetPosition : MonoBehaviour
{
    
    public Vector3 resetPosition;

    private void OnTriggerEnter(Collider other)
    {
      
        if (other.CompareTag("Louise")) 
        {
           
            other.transform.position = resetPosition;
        }
    }
}
