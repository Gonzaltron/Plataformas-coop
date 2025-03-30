using UnityEngine;

public class SwitchPlatforms : MonoBehaviour
{
    public bool activated;
    public Vector3 positionOn;
    public Vector3 positionOff;
    [SerializeField] public Transform Platform;
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
    }
}
