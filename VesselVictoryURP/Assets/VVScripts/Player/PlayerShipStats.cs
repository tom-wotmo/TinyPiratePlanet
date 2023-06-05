using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShipStats  : Stats
{
    [SerializeField] private float health;
    [SerializeField] private float shipAmmo = 0f;

    [SerializeField] private Text ammoUItext;


    private void Start()
    {
        health = DEFAULT_MAXIMUM_HEALTH;
        shipName = "PlayerShip";
    }
    private void Update()
    {
        ammoUItext.text = shipAmmo.ToString();
        Death();
    }
    public override void Death()
    {
        if (health <= DEFAULT_MINIMUM_HEALTH)
        {
            ScoreHandler.Instance.SaveScore();
            MenuFunctionality.Instance.RestartGame();
        }
    }
    public float getPlayerShipAmmo() { return shipAmmo; }
    public void setPlayerShipAmmo(float ammo) { shipAmmo = ammo; }
    public float getPlayerShipHealth() { return health; }
    public void setPlayerShipHealth(float i) { health = i; }

}
