using Unity.VisualScripting;
using UnityEngine;

public class Camera_follow : MonoBehaviour
{
    [SerializeField] Vector3 offset;
    public float smoothTime;  //el suevizado de la camara
    private Vector3 velocity = Vector3.zero;
    [SerializeField] private Transform target;  //transform del obejtivo de la camara y del segundo personaje
    [SerializeField] private Transform P2;      //transform del obejtivo de la camara y del segundo personaje
    private Camera mainCamera;
    public float maxFov;          //field of view maxima y minima
    public float minFov;          //field of view maxima y minima
    public float zoomSpeed;
    [SerializeField] private Camera cam = default;
    [SerializeField] public GameObject canvas; //declaracion publica de canvas

    void Start()
    {
       mainCamera = Camera.main;
       canvas.SetActive(false); //inicializa el canvas como inactivo
    }

    void FixedUpdate()
    {
        cam.transform.Rotate(0, 0, 0); //No hay rotación de la cámara
        Vector3 targetPosition = target.position + offset; //añadir el offset a la posición dela camara
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime); //Poner la camara en la posición del jugador, aplicar el movimiento suave, y la velocidad del zoom de la camara

        //conseguir la distancia entre los dos jugadores
        float distancex = target.position.x - P2.position.x;
        float distancey = target.position.y - P2.position.y;
        float distance = Mathf.Sqrt(distancex * distancex + distancey * distancey);

        Vector2 midle = new Vector2((target.position.x + P2.position.x) / 2, (target.position.y + P2.position.y) / 2); //calcular el punto medio entre los jugadores
        transform.position = new Vector3(midle.x, midle.y, transform.position.z); //mover la camara al medio de los dos jugadores
        float normalizedDistance = distance / 10 * zoomSpeed; //Normalizar la distancia a un valor entre 0 y 1
        float fov = Mathf.Lerp(minFov, maxFov, normalizedDistance); //establecer el zoom de la camara entre dos valores, teniendo en cuenta la normal de la distncia
        Camera.main.fieldOfView = fov;


        if (Input.GetKeyDown(KeyCode.P)) //Si se pulsa escape, se activa el menu de pausa
        {
                if(canvas.activeSelf) //Si el canvas esta activo
                {
                    canvas.SetActive(false); //Desactiva el canvas
                    Time.timeScale = 1; //Reanuda el tiempo del juego
                }
                else
                {
                    canvas.SetActive(true); //activa el canvas
                    Time.timeScale = 0; //Pausa el tiempo del juego
                }
        }
    }
}