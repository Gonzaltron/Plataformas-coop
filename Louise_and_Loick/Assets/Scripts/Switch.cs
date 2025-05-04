using UnityEngine;

public class Switch : MonoBehaviour
{
    public bool activated;
    public Vector2 positionOn;
    public Vector2 positionOff;
    [SerializeField] public Transform Door;
    public Vector2 doorOff;
    public Vector2 doorOn;
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        activated = false;
        this.transform.position = positionOff;
        Door.transform.position = doorOff;
       
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D other)
    {
        activated = true;
        this.transform.position = positionOn;
        Door.transform.position = doorOn;
       

        
    }

    void OnTriggerExit2D(Collider2D other)
    {
        activated = false;
        this.transform.position = positionOff;
        Door.transform.position = doorOff;

    }
}
