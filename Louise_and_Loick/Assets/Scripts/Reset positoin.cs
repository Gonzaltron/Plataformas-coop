using Unity.VisualScripting;
using UnityEngine;

public class ResetPosition : MonoBehaviour
{

    public Vector3 resetPosition;
    [SerializeField] private Transform P1;
    [SerializeField] private Transform P2;
    public bool isDead;

    void Start()
    {
        isDead = false;
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Death")) //si uno de los jugadores colisiona con el objeto con el tag Death
        {
            //la posicion de ambos jugadores se resetea a la ultima posicion del checkpoint
            P1.transform.position = resetPosition; 
            P2.transform.position = resetPosition;
            isDead = true;
        }

        if (collision.gameObject.CompareTag("BigSpike")) //si uno de los jugadores colisiona con el objeto con el tag Death
        {
            //la posicion de ambos jugadores se resetea a la ultima posicion del checkpoint
            P1.transform.position = resetPosition;
            P2.transform.position = resetPosition;
            isDead = true;
        }


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Checkpoint")) //si uno de los jugadores colisiona con el trigger con el tag Checkpoint
        {
            //la posicion de reseteo se actualiza a la posicion del checkpoint
            resetPosition = collision.gameObject.transform.position;
        }
    }
}
