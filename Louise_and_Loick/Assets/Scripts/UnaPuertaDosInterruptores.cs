using UnityEngine;

public class UnaPuertaDosInterruptores : MonoBehaviour
{
    public DosInterruptoresUnapuerta Valorguardado1;
    public DosInterruptoresUnapuerta Valorguardado2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Valorguardado1.contador >= 1 && Valorguardado2.contador >= 1)
        {
            Valorguardado1.Door.transform.position = Valorguardado1.doorOn;
        }
        if (Valorguardado1.contador == 0 || Valorguardado2.contador == 0 || Valorguardado1.contador == 0 && Valorguardado2.contador == 0)
        {
            Valorguardado1.Door.transform.position = Valorguardado1.doorOff;
        }
    }
}
