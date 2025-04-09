using UnityEngine;
using UnityEngine.UIElements;

public class Moving_platform : MonoBehaviour
{
    //We pass two points to delimit the platform
    [SerializeField] private Transform Position1, Position2;
    [SerializeField] private float _speed;
    //We use it to change the movement of the platform
    private bool _switch = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
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
}
