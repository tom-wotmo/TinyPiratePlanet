using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerShipStats  : Stats
{
    [SerializeField] private float health;
    [SerializeField] private float shipAmmo = 0f;
    [SerializeField] private TextMeshProUGUI ammoUITMP;
    [SerializeField] private AudioClip deathClip;

   

    private void Start()
    {
        health = DEFAULT_MAXIMUM_HEALTH;
        shipName = "PlayerShip";
       
    }
    private void Update()
    {
        ammoUITMP.text = shipAmmo.ToString();
        MaxHealthCheck();
        Death();
    }
    public override void Death()
    {
        if (health <= DEFAULT_MINIMUM_HEALTH)
        {
            ScoreHandler.Instance.UpdateHighScore();
            MenuFunctionality.Instance.GameOverScreen();
            AudioManager.Instance.PlayOneShotSound(deathClip, 0.5f);

        }
    }
    private void MaxHealthCheck()
    {
        if(health > DEFAULT_MAXIMUM_HEALTH)
        {
            health = DEFAULT_MAXIMUM_HEALTH;
        }
    }
    public float getPlayerShipAmmo() { return shipAmmo; }
    public void setPlayerShipAmmo(float ammo) { shipAmmo = ammo; }
    public float getPlayerShipHealth() { return health; }
    public void setPlayerShipHealth(float i) { health = i; }

}
