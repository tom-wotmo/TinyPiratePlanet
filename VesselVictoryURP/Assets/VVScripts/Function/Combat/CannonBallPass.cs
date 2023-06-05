
using UnityEngine;

public class CannonBallPass : MonoBehaviour
{
    [SerializeField]private float delay = 0.5f;
    [SerializeField]private float projectileDamage = 10f;
    void Start()
    {
        Destroy(gameObject, delay);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("EnemyBoat"))
        {
            Destroy(gameObject);     
        }
        else if (other.gameObject.layer == LayerMask.NameToLayer("PlayerBoat"))
        {
            Destroy(gameObject);
        }
    }
    public float getProjectileDamage() { return projectileDamage; }
   


}
