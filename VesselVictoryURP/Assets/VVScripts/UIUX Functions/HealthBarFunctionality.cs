using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarFunctionality : MonoBehaviour
{
    private Image healthBar;
    private PlayerShipStats playerShipStats;
    void Update()
    {
        UpdateHealthBar();
    }
    private void Start()
    {
        playerShipStats = FindFirstObjectByType<PlayerShipStats>();
        healthBar = this.gameObject.GetComponent<Image>();
    }

    private void UpdateHealthBar()
    {
        healthBar.fillAmount = playerShipStats.getPlayerShipHealth() / 100f;
    }
}
