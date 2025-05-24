using System;
using UnityEngine;

public class ResetCaja : MonoBehaviour
{
    [SerializeField] public Transform Caja; //referencia publica a la caja
    public Vector2 PosicionCaja; // posición inicial de la caja
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //al entrar en colision
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //si la colision es con el pincho
        if (collision.gameObject.CompareTag("Tag 4 Spike"))
        {
            Caja.transform.position = PosicionCaja; //la caja vuelve a su posicion inicial
        }
        
    }
    
}
