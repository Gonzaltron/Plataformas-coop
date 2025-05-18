using UnityEngine;
using System.Collections;

public class ChorroDeAgua : MonoBehaviour
{
    public float delay;
    public Vector3 IN;
    public Vector3 OUT;
    public GameObject d;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        IN = this.transform.position;
        OUT = IN + new Vector3(2000, 0, 0);
        this.transform.position = IN;
        StartCoroutine(DelayTime());
    }

    // Corrutina para manejar el retraso
    IEnumerator DelayTime()
    {
        while (true)
        {
            this.transform.position = IN;
            yield return new WaitForSeconds(delay);
            this.transform.position = OUT;
            yield return new WaitForSeconds(delay);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Box"))
        {
            d.SetActive(false);
        }
    }
}


