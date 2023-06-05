
using UnityEngine;

public class PlayerCombatManager : MonoBehaviour
{
    [SerializeField] private CannonBallPass projectileStats;
    private PlayerShipStats thisShipStats;
    private float thisShipHealth;
    private float projectileDamage;
    private void Start()
    {
        thisShipStats = GetComponent<PlayerShipStats>();

    }
    private void Update()
    {
        thisShipHealth = thisShipStats.getPlayerShipHealth();
        projectileDamage = projectileStats.getProjectileDamage();

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("EnemyProjectiles"))
        {
            thisShipStats.setPlayerShipHealth(thisShipHealth - projectileDamage);

        }
    }
}
