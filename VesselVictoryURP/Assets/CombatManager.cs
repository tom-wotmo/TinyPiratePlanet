using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    private EnemyBoatStats enemyStats;
    private float thisShipHealth;
    private void Start()
    {
        enemyStats = GetComponent<EnemyBoatStats>();
       
    }
    private void Update()
    {
        thisShipHealth = enemyStats.getEnemyShipHealth();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Projectiles"))
        {
            enemyStats.setEnemyShipHealth(thisShipHealth - 10f);
            Debug.Log("Hit");
        }
    }

}
