using UnityEngine;

public class Ladder : MonoBehaviour
{
    [SerializeField] float speed;
    float arriba = 1.35f;
    float arriba2 = 5.9f;


    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Loick"))
        {

            if (Input.GetKey(KeyCode.UpArrow))
            {
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