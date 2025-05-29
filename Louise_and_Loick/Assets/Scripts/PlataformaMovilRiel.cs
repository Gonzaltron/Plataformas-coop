using UnityEngine;

public class PlataformaMovilRiel : MonoBehaviour
{
    //We pass an array of points to delimit the trayectory of the platform
    [SerializeField] private Transform[] Points;
    [SerializeField] private float _speed;
    public Louise louise;
    public Loick loick;

    public ResetPosition reset;
    public ResetPositionLouise resetLouise;
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
        //Si Louise o Loick mueren se reinicia la plataforma y su recorrido al principio
        if (reset.isDead || resetLouise.isDead)
        {
            Espera = false;
            loick.isMovingplatform = false;
            louise.isMovingplatform = false;
            IndexActual = 0;
            Point1 = Points[IndexActual].position;
            transform.position = Point1;
            Point2 = Points[IndexActual + 1].position;
            
            CalcularValores();
            reset.isDead = false;
            resetLouise.isDead = false;
            return;
        }
        //Cuando Louise y Loick han tocado la plataforma móvil
        if (louise.isMovingplatform == true && loick.isMovingplatform == true)
        {
            // Si se ha llegado al ultimo punto la plataforma se mantiene durante 10 segundos en la´ultima posicion antes de que vuelva al primer punto del recorrido
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
                //Si ha llegado al ultimo punto del recorrido se activa la variable de espera en true, sino seguirá moviendose entre puntos
                if (IndexActual == Points.Length - 1 )
                {
                    IndexActual = 0;
                    Espera = true;
                    return;
                }
                
                CalcularValores();
            }
            //Sirve para hacer que la plataforma se mueva por cada segundo y que no sea instantaneo
            transform.position = Vector2.Lerp(Point1, Point2, time);
        }


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Si Loick y Louise colisionan con la plataforma se activan las variables para indicar que la plataforma móvil se puede empezar a mover
        if (collision.gameObject.CompareTag("Loick"))
        {
            loick.isMovingplatform = true;
        }
        else if (collision.gameObject.CompareTag("Louise"))
        {
            louise.isMovingplatform = true;
        }
        //Si Louise, Loick o una caja colisionan con la plataforma, estos se moverán con ella (Es para que cuando estes quieto la plataforma móvil pueda moverse con Louise, Loick o una caja  )
        if (collision.gameObject.CompareTag("Louise") || collision.gameObject.CompareTag("Loick") || collision.gameObject.CompareTag("Box"))
        {
            collision.transform.SetParent(this.transform);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        //Si Louise, Loick o una caja dejan de colisionar con la plataforma, estos se moverán con ella (Es para que puedan seguir ejerciendo sus funciones cuando salen de la colision)
        if (collision.gameObject.CompareTag("Louise") || collision.gameObject.CompareTag("Loick") || collision.gameObject.CompareTag("Box"))
        {
            collision.transform.SetParent(null);
        }
    }
    //Se utiliza para calcular el tiempo que tiene que tardar para moverse entre los distintos puntos
    void CalcularValores()
    {
        Point1 = Points[IndexActual].position;
        Point2 = Points[IndexActual + 1].position;
        time = 0;
        //Con esto la velocidad será constante
        factorTime = 1.0f / Vector2.Distance(Point1, Point2) * _speed;
    }
  
    
}
