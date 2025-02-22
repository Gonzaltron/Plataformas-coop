using Unity.VisualScripting;
using UnityEngine;

public class Camera_follow : MonoBehaviour
{
 
    [SerializeField] Vector3 offset;
    public float smoothTime;
    private Vector3 velocity = Vector3.zero;
    [SerializeField] private Transform target;

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
