
using UnityEngine;

public class CannonBallPass : MonoBehaviour
{
    [SerializeField]private float delay = 0.5f;

    void Start()
    {
        Destroy(gameObject, delay);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("EnemyBoat"))
        {
            Destroy(gameObject);
            Debug.Log("Cannon Destroyed");
        }
    }

}
