using UnityEngine;

public class DosInterruptoresUnapuerta : MonoBehaviour
{
    public bool activated;
    public Vector2 positionOn;
    public Vector2 positionOff;
    [SerializeField] public Transform Door;
    public Vector2 doorOff;
    public Vector2 doorOn;

    public int contador;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        activated = false;
        this.transform.position = positionOff;
        Door.transform.position = doorOff;
        contador = 0;
        positionOff = Door.transform.position;
        positionOn = Door.transform.position + new Vector3(2000, 0, 0);
    }


    // Update is called once per frame
    void Update()
    {
        if (activated == true)
        {
            this.transform.position = positionOn;
        }
        if (activated == false)
        {
            this.transform.position = positionOff;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        activated = true;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        contador++;
    }
    void OnTriggerExit2D(Collider2D other)
    {
        activated = false;
        contador--;
    }
}
