using UnityEngine;

public class PlataformaMovilRiel : MonoBehaviour
{
    //We pass an array of points to delimit the trayectory of the platform
    [SerializeField] private Transform[] Points;
    [SerializeField] private float _speed;
    public Louise louise;
    public Loick loick;

    public ResetPosition reset;
    float cronometro = 0;
    bool Espera = false;
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
        if (reset.isDead == true)
        {
            loick.isMovingplatform = false;
            louise.isMovingplatform = false;
            IndexActual = 0;
            Point1 = Points[IndexActual].position;
            transform.position = Point1;
            Point2 = Points[IndexActual + 1].position;
            
            CalcularValores();
            reset.isDead = false;

            return;
        }
        if (louise.isMovingplatform == true && loick.isMovingplatform == true)
        {
            
            if (Espera)
            {
                cronometro += Time.deltaTime;
                if (cronometro >= cronometromax)
                {
                    Espera = false;
                    cronometro = 0;
                    IndexActual = 0;
                    CalcularValores();
                }
                return;
            }
            time += factorTime * Time.deltaTime;
            if (time >= 1f)
            {
                IndexActual++;

                if (IndexActual == Points.Length - 1 )
                {
                    IndexActual = 0;
                    Espera = true;
                    return;
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
        time = 0;

        factorTime = 1.0f / Vector2.Distance(Point1, Point2) * _speed;
    }
}
