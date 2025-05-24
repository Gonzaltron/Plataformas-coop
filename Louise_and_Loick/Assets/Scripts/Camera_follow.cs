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
        cam.transform.Rotate(0, 0, 0); //No hay rotaci�n de la c�mara
        Vector3 targetPosition = target.position + offset; //a�adir el offset a la posici�n dela camara
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime); //Poner la camara en la posici�n del jugador, aplicar el movimiento suave, y la velocidad del zoom de la camara

        //conseguir la distancia entre los dos jugadores
        float distancex = target.position.x - P2.position.x;
        float distancey = target.position.y - P2.position.y;
        float distance = Mathf.Sqrt(distancex * distancex + distancey * distancey);

        Vector2 midle = new Vector2((target.position.x + P2.position.x) / 2, (target.position.y + P2.position.y) / 2); //calcular el punto medio entre los jugadores
        transform.position = new Vector3(midle.x, midle.y, transform.position.z); //mover la camara al medio de los dos jugadores
        float normalizedDistance = distance / 10 * zoomSpeed; //Normalizar la distancia a un valor entre 0 y 1
        float fov = Mathf.Lerp(minFov, maxFov, normalizedDistance); //establecer el zoom de la camara entre dos valores, teniendo en cuenta la normal de la distncia
        Camera.main.fieldOfView = fov; 
    }
}