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
    [SerializeField] private Camera cam = default;

    void Start()
    {
       mainCamera = Camera.main;
    }

    void FixedUpdate()
    {
        cam.transform.Rotate(0, 0, 0);
        Vector3 targetPosition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);

        //conseguir la distancia entre los dos jugadores
        float distancex = target.position.x - P2.position.x;
        float distancey = target.position.y - P2.position.y;
        float distance = Mathf.Sqrt(distancex * distancex + distancey * distancey);

        Vector2 midle = new Vector2((target.position.x + P2.position.x) / 2, (target.position.y + P2.position.y) / 2);
        transform.position = new Vector3(midle.x, midle.y, transform.position.z); //mover la camara al medio de los dos jugadores
        float normalizedDistance = distance / 10 * zoomSpeed;
        float fov = Mathf.Lerp(minFov, maxFov, normalizedDistance);
        Camera.main.fieldOfView = fov;

        /*
        float normalizedDistance = distance/10 * zoomSpeed; //normalizar el vector, y ajustar la velocidad de zoom
        float fov = Mathf.Lerp(minFov, maxFov, normalizedDistance); //interpolacion lineal para el zoom (hacer que cambien segun la distancia entre los dos jugadores)
        Camera.main.fieldOfView = fov;
        */
    }
}