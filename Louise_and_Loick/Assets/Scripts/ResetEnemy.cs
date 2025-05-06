using UnityEngine;

public class ResetEnemy : MonoBehaviour
{
    [SerializeField] Enemigo_Nivel4 e; 
    [SerializeField] ResetPosition reset;
    [SerializeField] ResetPositionLouise r;
    public Vector2 PosicionEnemigo;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (reset.isDead == true || r.isDead == true)
        {
            e.transform.position = PosicionEnemigo;
        }
    }
}
