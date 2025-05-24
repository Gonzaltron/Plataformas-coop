using Unity.VisualScripting;
using UnityEngine;

public class ResetPosition : MonoBehaviour
{
    
    public Vector3 resetPositionLoick;  
    [SerializeField] private Transform P1;   //crear los transform de posicion de reseteo
    [SerializeField] private Transform P2;   //crear los transform de posicion de reseteo
    public bool isDead;
    public Vector3 resetPositionLouise;                    //Declarar las variables de reset position
    public ResetPositionLouise resetPositionLouiseScript;  //Declarar las variables de reset position

    void Start()
    {
        //conseguir la variable reset position de la clase ResetPositionLouise
        resetPositionLouiseScript = P1.GetComponent<ResetPositionLouise>();     
        resetPositionLouise = resetPositionLouiseScript.resetPositionLouise;    
        isDead = false;
    }

    void Update()
    {
        resetPositionLouise = resetPositionLouiseScript.resetPositionLouise; //establecer las coorenadas de la variable resetPosiitonLouise
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Si uno de los jugadores colisiona con el objeto con el tag Death, BigSpike, Steam o Enemy
        // Se declara la variable audioSource y se reproduce el sonido de muerte
        if (collision.gameObject.CompareTag("Death")) //si uno de los jugadores colisiona con el objeto con el tag Death
        {
            var audioSource = GetComponent<AudioSource>();
            audioSource.Play();
            //la posicion de ambos jugadores se resetea a la ultima posicion del checkpoint
            P1.transform.position = resetPositionLouise; 
            P2.transform.position = resetPositionLoick;
            isDead = true;
        }

        else if (collision.gameObject.CompareTag("BigSpike")) //si uno de los jugadores colisiona con el objeto con el tag Death
        {
            var audioSource = GetComponent<AudioSource>();
            audioSource.Play();
            //la posicion de ambos jugadores se resetea a la ultima posicion del checkpoint
            P1.transform.position = resetPositionLouise;
            P2.transform.position = resetPositionLoick;
            isDead = true;
        }
        else if (collision.gameObject.CompareTag("Steam") || collision.gameObject.CompareTag("Enemy")) //si uno de los jugadores colisiona con el objeto con el tag Death
        {
            var audioSource = GetComponent<AudioSource>();
            audioSource.Play();
            //la posicion de ambos jugadores se resetea a la ultima posicion del checkpoint
            P1.transform.position = resetPositionLouise;
            P2.transform.position = resetPositionLoick;
            isDead = true;
        }


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Checkpoint")) //si uno de los jugadores colisiona con el trigger con el tag Checkpoint
        {
            //la posicion de reseteo se actualiza a la posicion del checkpoint
            resetPositionLoick = this.gameObject.transform.position + new Vector3 (2, 0, 0);
        }

        // Si uno de los jugadores colisiona con el trigger con el tag Death
        if (collision.gameObject.CompareTag("Death"))
        {
            // Se declara la variable audioSource y se reproduce el sonido de muerte
            var audioSource = GetComponent<AudioSource>();
            audioSource.Play();
            //la posicion de ambos jugadores se resetea a la ultima posicion del checkpoint
            P1.transform.position = resetPositionLouise;
            P2.transform.position = resetPositionLoick;
        }
    }
}
