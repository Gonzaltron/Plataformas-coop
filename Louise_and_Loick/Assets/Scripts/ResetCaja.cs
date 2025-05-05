using System;
using UnityEngine;

public class ResetCaja : MonoBehaviour
{
    [SerializeField] public Transform Caja;
    public Vector2 PosicionCaja;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Tag 4 Spike"))
        {
            Caja.transform.position = PosicionCaja;
        }
        
    }
    
}
