using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipStats : Stats
{
    private float health;
    private int id;
   
    private void Start()
    {
        health = DEFAULT_MAXIMUM_HEALTH;
        id = DEFAULT_ID;

        shipName = "enemyShip";
    }
    private void Update()
    {
        Death();
    }
    public override void Death()
    {
        if (health <= DEFAULT_MINIMUM_HEALTH)
        {
            Destroy(this.gameObject);
        }
    }
    public float getEnemyShipHealth() { return health; }
    public void setEnemyShipHealth(float i) { health = i; }

    public void setEnemyShipId(int i) { id = i; }



}
