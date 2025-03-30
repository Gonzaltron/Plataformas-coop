using UnityEngine;

public class DisapearingPlatform : MonoBehaviour
{
    bool activatedP;
    private Rigidbody2D rb;
    public SwitchPlatforms switchPlatforms; // Referencia p�blica a SwitchPlatforms
    public Collider2D collider2D;
    public Vector3 triggerOff;
    public Vector3 triggerOn;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        activatedP = false;
        rb = GetComponent<Rigidbody2D>();
        collider2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update(Collider2D other)
    {
        Rigidbody2D otherRb = other.GetComponent<Rigidbody2D>();
        if (switchPlatforms.activated == true)
        {
            GetComponent<Collider2D>().enabled = false;
            this.transform.position = triggerOff;
        }
        else
        {
            GetComponent<Collider2D>().enabled = true;
            this.transform.position = triggerOn;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        activatedP = true;
        Rigidbody2D otherRb = other.GetComponent<Rigidbody2D>();
        otherRb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
        
    }

    void OnTriggerExit2D(Collider2D other)
    {
        activatedP = false;
        Rigidbody2D otherRb = other.GetComponent<Rigidbody2D>();
        otherRb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    public void DisableTrigger()
    {
        if (switchPlatforms.activated == true)
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