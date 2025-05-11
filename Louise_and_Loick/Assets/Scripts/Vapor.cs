using UnityEngine;

public class Vapor : MonoBehaviour
{
    public Valve valve;
    private Animator animator;

    void Start()
    {
        valve = GameObject.Find("Valve").GetComponent<Valve>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (valve.IsVaporOn())
        {
            animator.SetBool("Activado", false);
        }
        else
        {
            animator.SetBool("Activado", true);
        }
    }
}
