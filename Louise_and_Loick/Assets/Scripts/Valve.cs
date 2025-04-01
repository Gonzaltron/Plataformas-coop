using UnityEngine;

public class Valve : MonoBehaviour
{
    public bool activated;
    public Vector3 ON;
    public Vector3 OFF;
    [SerializeField] public Transform Steam;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        activated = false;
    }


    // Update is called once per frame
    void Update()
    {
        if (activated == true && Input.GetKey(KeyCode.E))
        {
            Steam.transform.position = ON;
            activated = false;
        }
    }
   
    void OnTriggerEnter2D(Collider2D other)
    {
        activated = true;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        activated = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        activated = false;
        Steam.transform.position = OFF;
    }
}
