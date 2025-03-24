using UnityEngine;

public class DisapearingPlatform : MonoBehaviour
{
    bool activatedP;
    private Rigidbody2D rb;
    public SwitchPlatforms switchPlatforms;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       activatedP = false;
       rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update(Collider2D other)
    {
        Rigidbody2D otherRb = other.GetComponent<Rigidbody2D>();
        if (otherRb != null)
        {
            if (activatedP == true)
            {
                otherRb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
            }
        }
        if (switchPlatforms.activated == true)
        {
                activatedP = false;
                otherRb.constraints = RigidbodyConstraints2D.None; 

        }
    }

    


    void OnTriggerEnter2D(Collider2D other)
    {
        activatedP = true;
    }
}
