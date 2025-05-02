using UnityEngine;
using System.Collections;

public class Valve : MonoBehaviour
{
    public bool activated;
    public Vector2 ON;
    public Vector2 OFF;
    bool ONcheck;
    [SerializeField] public Transform Steam;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        activated = false;
        ONcheck = false;
    }


    // Update is called once per frame
    void Update()
    {
        if (activated == true && Input.GetKeyDown(KeyCode.E))
        {
            if (ONcheck == true)
            {
                Steam.transform.position = OFF;
                
                activated = false;
            }
            else if (ONcheck == false)
            {
                Steam.transform.position = ON;
         
                activated = false;
            }
            activated = false;
            StartCoroutine(DelayTime2());
            Debug.Log("Ha esperado");
            if (ONcheck == true)
            {
                ONcheck = false;
            }
            else if (ONcheck == false)
            {
                ONcheck = true;
            }
            StartCoroutine(WaitForFrames(30));
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

    IEnumerator DelayTime()
    {
        
        yield return new WaitForSeconds(1.0f);
    }

    IEnumerator DelayTime2()
    {
        yield return new WaitForSeconds(0.5f);
        Debug.Log("Iniciando movimiento del agua");
    }

    IEnumerator WaitForFrames(int frames)
    {
        for (int i = 0; i < frames; i++)
        {
            yield return null; 
        }
    }
}
