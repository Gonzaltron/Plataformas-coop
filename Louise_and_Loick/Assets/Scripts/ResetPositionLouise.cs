using UnityEngine;

public class ResetPositionLouise : MonoBehaviour
{

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
        resetPositionLoick = resetPositionScript.resetPositionLoick;
        isDead = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Death") || collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Steam")) //si uno de los jugadores colisiona con el objeto con el tag Death
        {
            //la posicion de ambos jugadores se resetea a la ultima posicion del checkpoint
            P1.transform.position = resetPositionLouise;
            P2.transform.position = resetPositionLoick;
            isDead = true;
            
        }

        if (collision.gameObject.CompareTag("Tag 4 Spike") || collision.gameObject.CompareTag("BigSpike"))
        {
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
        }

        if(collision.gameObject.CompareTag("Death"))
        {
            //la posicion de ambos jugadores se resetea a la ultima posicion del checkpoint
            P1.transform.position = resetPositionLouise;
            P2.transform.position = resetPositionLoick;
        }
    }
}