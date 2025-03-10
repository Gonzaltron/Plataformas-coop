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
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void FixedUpdate()
    {
        Vector3 targetPosition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);

        float distance = Vector3.Distance(target.position, P2.position);
        float normalizedDistance = Mathf.InverseLerp(0, 100, distance); // Ajusta 100 al valor máximo esperado de distancia
        float fov = Mathf.Lerp(minFov, maxFov, normalizedDistance)+10;
        mainCamera.fieldOfView = fov;
    }
}

