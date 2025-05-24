using UnityEngine;
using System.Collections;

public class ChorroDeAgua : MonoBehaviour
{
    public float delay;
    public Vector3 IN;    //se declaran las posiciones in y out
    public Vector3 OUT;   //se declaran las posiciones in y out
    public GameObject d;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        IN = this.transform.position;           //Se fijan las posiciones in y out
        OUT = IN + new Vector3(2000, 0, 0);     //Se fijan las posiciones in y out
        this.transform.position = IN;
        StartCoroutine(DelayTime()); //empieza la corutina de cambio de posicion
    }

    // Corrutina para manejar el retraso
    IEnumerator DelayTime()
    {
        //mientras el rograma se ejecute
        while (true)
        {
            //cambia la posicion del objeto entre IN y OUT, esperando DELAY entre cambio y cambio
            this.transform.position = IN;
            yield return new WaitForSeconds(delay);
            this.transform.position = OUT;
            yield return new WaitForSeconds(delay);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //si colisiona con la caja, se desactiva el objeto
        if (collision.gameObject.CompareTag("Box"))
        {
            d.SetActive(false);
        }
    }
}


