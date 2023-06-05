using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShipStats  : Stats
{
    [SerializeField] private float health;
    [SerializeField] private float shipAmmo = 0f; 

    private void Start()
    {
        health = DEFAULT_MAXIMUM_HEALTH;
        shipName = "PlayerShip";
    }
    private void Update()
    {
        Death();
    }
    public override void Death()
    {
        if (health <= DEFAULT_MINIMUM_HEALTH)
        {
            ScoreHandler.Instance.SaveScore();
            MenuFunctionality.Instance.RestartGame();
            Debug.Log("Player has died");
        }
    }
    public float getPlayerShipAmmo() { return shipAmmo; }
    public void setPlayerShipAmmo(float ammo) { shipAmmo = ammo; }
    public float getPlayerShipHealth() { return health; }
    public void setPlayerShipHealth(float i) { health = i; }

}
