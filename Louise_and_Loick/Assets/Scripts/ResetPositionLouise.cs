using UnityEngine;

public class ResetPositionLouise : MonoBehaviour
{

    public Vector3 resetPosition;
    [SerializeField] private Transform P1;
    [SerializeField] private Transform P2;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Death")) //si uno de los jugadores colisiona con el objeto con el tag Death
        {
            //la posicion de ambos jugadores se resetea a la ultima posicion del checkpoint
            P1.transform.position = resetPosition;
            P2.transform.position = resetPosition;
        }

        if (collision.gameObject.CompareTag("Tag 4 Spike") || collision.gameObject.CompareTag("BigSpike"))
        {
            //la posicion de ambos jugadores se resetea a la ultima posicion del checkpoint
            P1.transform.position = resetPosition;
            P2.transform.position = resetPosition;
        }


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Checkpoint")) //si uno de los jugadores colisiona con el trigger con el tag Checkpoint
        {
            //la posicion de reseteo se actualiza a la posicion del checkpoint
            resetPosition = collision.gameObject.transform.position;
        }
    }
}