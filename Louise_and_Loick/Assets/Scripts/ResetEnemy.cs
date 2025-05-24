using UnityEngine;

public class ResetEnemy : MonoBehaviour
{
    [SerializeField] Enemigo_Nivel4 e;
    public Vector2 PosicionEnemigo;
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
        //si es con algo de esto
        if (collision.gameObject.CompareTag("Louise") || collision.gameObject.CompareTag("Loick") || collision.gameObject.CompareTag("Steam"))
        {
            e.transform.position = PosicionEnemigo; //vuelve a su posicion inicial
        }

    }
}