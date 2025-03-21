using UnityEngine;

public class Switch : MonoBehaviour
{
    public bool activated;
    public Vector3 positionOn;
    public Vector3 positionOff;
    [SerializeField] public Transform Door;
    public Vector3 doorOff;
    public Vector3 doorOn;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        activated = false;
    }


    // Update is called once per frame
    void Update()
    {
        if (activated == true)
        {
            this.transform.position = positionOn;
            Door.transform.position = doorOn;
            activated = false;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        activated = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        activated = false;
        this.transform.position = positionOff;
        Door.transform.position = doorOff;

    }
}
