using Unity.VisualScripting;
using UnityEngine;

public class Camera_follow : MonoBehaviour
{
 
    [SerializeField] Vector3 offset;
    public float smoothTime;
    private Vector3 velocity = Vector3.zero;
    [SerializeField] private Transform target;
    [SerializeField] private Transform P2;
    public float maxFov;
    public float minFov;

    
    void fixedUpdate()
    {
        Vector3 targetPosition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        Vector3.position getDistancex = (targetPositionx - P2positionx) * (targetPositionx - P2positionx);
        Vector3.position getDistancey = (targetPositiony - P2positiony) * (targetPositiony - P2positiony),
        Vector3.position getDistance = Mathf.sqrt(getDistancex + getDistancey);
        float fov = Mathf.Lerp(minFov, maxFov, getDistance);
    }
}

