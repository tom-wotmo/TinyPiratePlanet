using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateSpawner : Spawner
{
    public static CrateSpawner Instance;
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
