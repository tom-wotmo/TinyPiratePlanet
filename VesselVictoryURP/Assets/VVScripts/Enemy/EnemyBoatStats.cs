using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoatStats : MonoBehaviour
{
    [SerializeField]private float enemyShipHealth;
    private void Start()
    {
        enemyShipHealth = 100;
    }
    private void Update()
    {
        enemyShipDeath();
    }
    private void enemyShipDeath()
    {
        if(enemyShipHealth <= 0) { Destroy(gameObject); }
    }
    public float getEnemyShipHealth() { return enemyShipHealth; }
    public void setEnemyShipHealth(float i) { enemyShipHealth = i; }
}
