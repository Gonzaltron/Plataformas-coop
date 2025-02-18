using Unity.VisualScripting;
using UnityEngine;

public class Camera_follow : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] float bounds;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 distance = transform.position - player.transform.position;
        if(Mathf.Abs(distance.x) > bounds)
        {
            transform.position = new Vector3(player.transform.position.x + bounds + Mathf.Sign(distance.x), transform.position.y, transform.position.z);
        }

        if(Mathf.Abs(distance.y) > bounds)
        {
            transform.position = new Vector3(transform.position.x, player.transform.position.y +  bounds + Mathf.Sign(distance.y), transform.position.z); 
        }
    }
}
