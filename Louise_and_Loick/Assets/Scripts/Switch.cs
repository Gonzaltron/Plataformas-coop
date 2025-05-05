using UnityEngine;

public class Switch : MonoBehaviour
{
    public bool activated;
    [SerializeField] public Transform Door;
    public Vector2 doorOff;
    public Vector2 doorOn;
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        activated = false;
       
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D other)
    {
        activated = true;
        if (activated == true)
        {
            Door.transform.position = doorOn;
        }
       
       

        
    }

    void OnTriggerExit2D(Collider2D other)
    {
        activated = false;
        if (activated == false)
        {
            Door.transform.position = doorOff;
        }
       

    }
}
