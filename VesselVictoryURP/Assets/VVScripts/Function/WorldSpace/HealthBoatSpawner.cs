using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBoatSpawner : Spawner
{
    public static HealthBoatSpawner Instance;

    private PlayerShipStats ship;
    private float playerShipHealth, maximumShipHealth;
    private void Start()
    {
        ship = FindFirstObjectByType<PlayerShipStats>();
    }
    private void Awake()
    {
        if (Instance == null)
        { Instance = this; }

    }
    private void Update()
    {
        playerShipHealth = ship.getPlayerShipHealth();
        maximumShipHealth = Stats.DEFAULT_MAXIMUM_HEALTH;

        if (playerShipHealth < maximumShipHealth)
        {
           
            StartCoroutine(SpawnPrefabsCoroutine(prefabToSpawn));

        }
    }
}
