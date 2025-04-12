using UnityEngine;

public class PlataformaMovilRiel : MonoBehaviour
{
    //We pass two points to delimit the platform
    [SerializeField] private Transform[] Points;
    [SerializeField] private float _speed;
    public Louise louise;
    public Loick loick;

    float cronometro = 0;
    float cronometromax = 10;
    int IndexActual = 0;
    Vector2 Point1;
    Vector2 Point2;
    float time;
    float factorTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        time = 1f;
        CalcularValores();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (louise.isMovingplatform == true && loick.isMovingplatform == true)
        {
            time += factorTime * Time.deltaTime;
            if (time >= 1f)
            {
                IndexActual++;

                if (IndexActual == Points.Length - 1)
                {
                    IndexActual = 0;

                }
               
                CalcularValores();
            }

            transform.position = Vector2.Lerp(Point1, Point2, time);
        }


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Loick"))
        {
            loick.isMovingplatform = true;
        }
        else if (collision.gameObject.CompareTag("Louise"))
        {
            louise.isMovingplatform = true;
        }
    }

    void CalcularValores()
    {
        Point1 = Points[IndexActual].position;
        Point2 = Points[IndexActual + 1].position;
        time = 1.0f - time;

        factorTime = 1.0f / Vector2.Distance(Point1, Point2) * _speed;
    }
}
