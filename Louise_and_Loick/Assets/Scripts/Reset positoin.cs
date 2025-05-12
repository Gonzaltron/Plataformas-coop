using Unity.VisualScripting;
using UnityEngine;

public class ResetPosition : MonoBehaviour
{
    
    public Vector3 resetPositionLoick;
    [SerializeField] private Transform P1;
    [SerializeField] private Transform P2;
    public bool isDead;
    public Vector3 resetPositionLouise;
    public ResetPositionLouise resetPositionLouiseScript;

    void Start()
    {
        resetPositionLouiseScript = P1.GetComponent<ResetPositionLouise>();
        resetPositionLouise = resetPositionLouiseScript.resetPositionLouise;
        isDead = false;
    }

    void Update()
    {
        resetPositionLouise = resetPositionLouiseScript.resetPositionLouise;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Death")) //si uno de los jugadores colisiona con el objeto con el tag Death
        {
            var audioSource = GetComponent<AudioSource>();
            audioSource.Play();
            //la posicion de ambos jugadores se resetea a la ultima posicion del checkpoint
            P1.transform.position = resetPositionLouise; 
            P2.transform.position = resetPositionLoick;
            isDead = true;
            isDead = false;
        }

        else if (collision.gameObject.CompareTag("BigSpike")) //si uno de los jugadores colisiona con el objeto con el tag Death
        {
            var audioSource = GetComponent<AudioSource>();
            audioSource.Play();
            //la posicion de ambos jugadores se resetea a la ultima posicion del checkpoint
            P1.transform.position = resetPositionLouise;
            P2.transform.position = resetPositionLoick;
            isDead = true;
            isDead = false;
        }
        else if (collision.gameObject.CompareTag("Steam") || collision.gameObject.CompareTag("Enemy")) //si uno de los jugadores colisiona con el objeto con el tag Death
        {
            var audioSource = GetComponent<AudioSource>();
            audioSource.Play();
            //la posicion de ambos jugadores se resetea a la ultima posicion del checkpoint
            P1.transform.position = resetPositionLouise;
            P2.transform.position = resetPositionLoick;
            isDead = true;
            isDead = false;
        }


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Checkpoint")) //si uno de los jugadores colisiona con el trigger con el tag Checkpoint
        {
            //la posicion de reseteo se actualiza a la posicion del checkpoint
            resetPositionLoick = this.gameObject.transform.position + new Vector3 (1, 0, 0);
        }

        if (collision.gameObject.CompareTag("Death"))
        {
            var audioSource = GetComponent<AudioSource>();
            audioSource.Play();
            //la posicion de ambos jugadores se resetea a la ultima posicion del checkpoint
            P1.transform.position = resetPositionLouise;
            P2.transform.position = resetPositionLoick;
        }
    }
}
