using UnityEngine;

public class DisapearingPlatform : MonoBehaviour
{
    private Rigidbody2D rb;
    public SwitchPlatforms switchPlatforms; // Referencia pública a SwitchPlatforms
    public Collider2D collider2D;
    bool activated = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        collider2D = GetComponent<BoxCollider2D>();
        switchPlatforms = GameObject.Find("SwitchPlatforms").GetComponent<SwitchPlatforms>(); // Busca el objeto SwitchPlatforms y obtiene su componente SwitchPlatforms
        activated = switchPlatforms.activated;

    }

    // Update is called once per frame
    void Update()
    {
        activated = switchPlatforms.activated;
        DisableTrigger();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Rigidbody2D otherRb = other.GetComponent<Rigidbody2D>();
        otherRb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
        
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Rigidbody2D otherRb = other.GetComponent<Rigidbody2D>();
        otherRb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    void DisableTrigger()
    {
       
        if ( activated == true)
        {
            collider2D.enabled = false;
            Debug.Log("Collider disabled");
        }
        else
        {
            collider2D.enabled = true;
        }
    }
}