using UnityEngine;

public class ResetPositionLouise : MonoBehaviour
{
    ////////////////ESTE SCRIPT HACE EXACTAMENTE LO MISNO QUE EL SCRIPT ResetPosition, PERO PARA LOUISE//////////////////

    public Vector3 resetPositionLouise;
    [SerializeField] private Transform P1;
    [SerializeField] private Transform P2;
    public bool isDead;
    public Vector3 resetPositionLoick;
    public ResetPosition resetPositionScript;

    void Start()
    {
        resetPositionScript = P2.GetComponent<ResetPosition>();
        resetPositionLoick = resetPositionScript.resetPositionLoick;
        isDead = false;
    }

    void Update()
    {
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Death") || collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Steam")) //si uno de los jugadores colisiona con el objeto con el tag Death
        {
            var audioSource = GetComponent<AudioSource>();
            audioSource.Play();
            //la posicion de ambos jugadores se resetea a la ultima posicion del checkpoint
            P1.transform.position = resetPositionLouise;
            P2.transform.position = resetPositionLoick;
            isDead = true;
            
        }

        if (collision.gameObject.CompareTag("Tag 4 Spike") || collision.gameObject.CompareTag("BigSpike"))
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
            resetPositionLouise = this.gameObject.transform.position;
            resetPositionLoick = this.gameObject.transform.position + new Vector3(1, 0, 0);

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