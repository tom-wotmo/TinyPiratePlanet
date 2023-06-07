using System.Collections;
using UnityEngine;

public class CannonBallPass : MonoBehaviour
{
    [SerializeField]private float delay = 0.5f;
    [SerializeField]private float projectileDamage = 10f;
   
    void Start()
    {
        Destroy(gameObject, delay);
        StartCoroutine(DestroyAfterDelay());
        
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
    private IEnumerator DestroyAfterDelay()
    {
        yield return new WaitForSeconds(0.3f);
        
    }
    public float getProjectileDamage() { return projectileDamage; }
   


}
