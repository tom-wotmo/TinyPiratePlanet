using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBoatSpawner : Spawner
{
    public static HealthBoatSpawner Instance;
    private void Awake()
    {
        if (Instance == null)
        { Instance = this; }

    }
    private void Update()
    {
        StartCoroutine(SpawnPrefabsCoroutine(prefabToSpawn));
    }
}
