using Unity.VisualScripting;
using UnityEngine;

public class Camera_follow : MonoBehaviour
{
    [SerializeField] Vector3 offset;
    public float smoothTime;
    private Vector3 velocity = Vector3.zero;
    [SerializeField] private Transform target;
    [SerializeField] private Transform P2;
    private Camera mainCamera;
    public float maxFov;
    public float minFov;
    public float zoomSpeed;

    void Start()
    {
       mainCamera = Camera.main;
    }

    void FixedUpdate()
    {
        Vector3 targetPosition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);

         float distancex = target.position.x - P2.position.x;
        float distancey = target.position.y - P2.position.y;
        float distance = Mathf.Sqrt(distancex * distancex + distancey * distancey);
        float normalizedDistance = distance/10 * zoomSpeed;
        float fov = Mathf.Lerp(minFov, maxFov, normalizedDistance);
        Camera.main.fieldOfView = fov;
    }
}