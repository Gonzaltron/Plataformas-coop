using UnityEngine;
using UnityEngine.UIElements;

public class Moving_platform : MonoBehaviour
{
    [SerializeField] private Transform Position1, Position2;
    [SerializeField] private float _speed;
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
            transform.position = Vector2.MoveTowards(transform.position, Position1.position, _speed * Time.deltaTime);
        }
        else if (_switch == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, Position2.position, _speed * Time.deltaTime);
        }

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
