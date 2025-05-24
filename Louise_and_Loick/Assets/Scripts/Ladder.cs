using UnityEngine;

public class Ladder : MonoBehaviour
{
    [SerializeField] float speed; //velocidad de movimiento en la escalera
    float arriba = 1.35f;     //valores para que los personajes en la escalera no caigan
    float arriba2 = 1.35f;    //valores para que los personajes en la escalera no caigan


    void OnTriggerStay2D(Collider2D other)
    {
        // Verifica si el objeto que entra en el trigger tiene el tag "Loick" o "Louise"
        if (other.gameObject.CompareTag("Loick"))
        {
            //Si se presionan las teclas de movimiento, los paersonajes se mueven a la direccion correspondiente a la velocidad Speed
            //Si la recla es arriba
            if (Input.GetKey(KeyCode.UpArrow))
            {
                //Se mueve hacia arribas
                other.GetComponent<Rigidbody2D>().linearVelocity = new Vector3(0, speed);

            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                other.GetComponent<Rigidbody2D>().linearVelocity = new Vector3(0, -speed);
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                other.GetComponent<Rigidbody2D>().linearVelocity = new Vector3(-speed, 0);
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                other.GetComponent<Rigidbody2D>().linearVelocity = new Vector3(speed, 0);
            }
            else
            {
                other.GetComponent<Rigidbody2D>().linearVelocity = new Vector3(0, arriba2);
            }
        }

        if (other.gameObject.CompareTag("Louise"))
        {

            if (Input.GetKey(KeyCode.W))
            {
                other.GetComponent<Rigidbody2D>().linearVelocity = new Vector3(0, speed);

            }
            else if (Input.GetKey(KeyCode.S))
            {
                other.GetComponent<Rigidbody2D>().linearVelocity = new Vector3(0, -speed);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                other.GetComponent<Rigidbody2D>().linearVelocity = new Vector3(-speed, 0);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                other.GetComponent<Rigidbody2D>().linearVelocity = new Vector3(speed, 0);
            }
            else
            {
                other.GetComponent<Rigidbody2D>().linearVelocity = new Vector3(0, arriba);
            }
        }
    }
}