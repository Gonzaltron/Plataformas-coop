using UnityEngine;
using System.Collections;

public class Switch : MonoBehaviour
{
    public bool activated;
    [SerializeField] public Transform Door;
    public Vector2 doorOff;
    public Vector2 doorOn;
    private Animator animator;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>(); // Obtener el Animator
        activated = false;
        doorOff = Door.transform.position;
        doorOn = Door.transform.position + new Vector3(2000, 0, 0);
        
    }


    // Update is called once per frame
    void Update()
    {
        
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        AudioPlay();
        DelayTime();
    }
    void OnTriggerStay2D(Collider2D other)
    {
        activated = true;
        
        Door.transform.position = doorOn;
        animator.SetBool("activado", true);
        
    }

    void OnTriggerExit2D(Collider2D other)
    {
        activated = false;
        Door.transform.position = doorOff;
        animator.SetBool("activado", false);
        AudioPlay();
        DelayTime();
    }

    void AudioPlay()
    {
        if(activated == true)
        {
            Door.GetComponent<AudioSource>().Play();
            DelayTime();
        }
        else if (activated == false)
        {
            Transform child = Door.GetChild(0);
            child.GetComponent<AudioSource>().Play();
            DelayTime();
        }
    }

    IEnumerator DelayTime()
    { 
        yield return new WaitForSeconds(0.5f);
    }
}
