
using UnityEngine;

public class PlayerCombatManager : MonoBehaviour
{
    [SerializeField] private CannonBallPass projectileStats;
    private ShipStats thisShipStats;
    private float thisShipHealth;
    private float projectileDamage;


    private void Start()
    {
        thisShipStats = GetComponent<ShipStats>();

    }
    private void Update()
    {
        thisShipHealth = thisShipStats.getShipHealth();
        projectileDamage = projectileStats.getProjectileDamage();

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("EnemyProjectiles"))
        {
            thisShipStats.setShipHealth(thisShipHealth - projectileDamage);

        }
    }
}
