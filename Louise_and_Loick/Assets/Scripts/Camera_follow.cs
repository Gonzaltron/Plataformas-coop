using Unity.VisualScripting;
using UnityEngine;

public class Camera_follow : MonoBehaviour
{
    [SerializeField] GameObject player1;
    [SerializeField] GameObject player2;
    [SerializeField] float bounds;
    [SerializeField] Vector3 offset;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(player1.transform.position, player2.transform.position);
        bounds = dist;
        transform.position = new Vector3(player1.transform.position.x, player1.transform.position.y + 5, player1.transform.position.z - 10);


    }
}
