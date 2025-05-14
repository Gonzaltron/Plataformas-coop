using UnityEngine;

public class ResetEnemy : MonoBehaviour
{

    public Vector2 PosicionEnemigo;
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
        if (collision.gameObject.CompareTag("Louise") || collision.gameObject.CompareTag("Loick") || collision.gameObject.CompareTag("Steam"))
        {
            e.transform.position = PosicionEnemigo;
        }

    }
}