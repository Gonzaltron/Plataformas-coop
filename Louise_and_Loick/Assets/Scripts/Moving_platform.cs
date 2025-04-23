using UnityEngine;
using UnityEngine.UIElements;
using static Unity.Collections.AllocatorManager;

public class Moving_platform : MonoBehaviour
{
    //We pass two points to delimit the platform
    [SerializeField] private Transform Position1, Position2;
    [SerializeField] private float _speed;
    //We use it to change the movement of the platform
    private bool _switch = false;
    public ResetPosition reset;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (reset.isDead == true)
        { 
            _switch = false;
            transform.position = Position1.position;
            reset.isDead = false;

            return;
        }
        if (_switch == false)
        {
            //We access to the position of this object and we move it to the Position1 object in every frame.  
            transform.position = Vector2.MoveTowards(transform.position, Position1.position, _speed * Time.deltaTime);
        }
        else if (_switch == true)
        {
            //We access to the position of this object and we move it to the Position1 object in every frame.
            transform.position = Vector2.MoveTowards(transform.position, Position2.position, _speed * Time.deltaTime);
        }
        //We change the value of _switch depending on the position of the platform
        if (transform.position == Position1.position)
        {
            _switch = true;
        }
        else if (transform.position == Position2.position)
        {
            _switch = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Louise") || collision.gameObject.CompareTag("Loick") || collision.gameObject.CompareTag("Box"))
        {
            collision.transform.SetParent(this.transform);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Louise") || collision.gameObject.CompareTag("Loick") || collision.gameObject.CompareTag("Box"))
        {
            collision.transform.SetParent(null);
        }
    }
}
