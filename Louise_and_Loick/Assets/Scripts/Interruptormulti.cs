using UnityEngine;

public class Interruptormulti : MonoBehaviour
{
    //Este interruptor solo se coloca cuando se necesitan abrir más de una puerta. Funciona como los interruptores normales.
    public bool activated;
    public Vector2 positionOn;
    public Vector2 positionOff;
    [SerializeField] public Transform Door;
    public Vector2 doorOff;
    public Vector2 doorOn;
    [SerializeField] public Transform Door2;
    public Vector2 doorOff2;
    public Vector2 doorOn2;
    [SerializeField] public Transform Door3;
    public Vector2 doorOff3;
    public Vector2 doorOn3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        activated = false;
        this.transform.position = positionOff;
        Door.transform.position = doorOff;
        Door2.transform.position = doorOff2;
        Door3.transform.position = doorOff3;
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
        Door2.transform.position = doorOn2;
        Door3.transform.position = doorOn3;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        activated = false;
        this.transform.position = positionOff;
        Door.transform.position = doorOff;
        Door2.transform.position = doorOff2;
        Door3.transform.position = doorOff3;

    }
}
