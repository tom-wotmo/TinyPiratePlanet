using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] protected GameObject prefabToSpawn;
    [SerializeField] protected GameObject worldSphere;
    [SerializeField] protected int maximumPrefabCountInScene = 3;
    [SerializeField] protected float timeToSpawn;
    
    private int currentPrefabCountInScene = 0;
    private void Update()
    {
        if (Time.time >= timeToSpawn) { spawnPrefabs(prefabToSpawn); }
    }
    protected virtual void spawnPrefabs(GameObject prefab)
    {
        float worldSphereRadius = worldSphere.transform.localScale.x / 2f;

        for (int i = 0; currentPrefabCountInScene < maximumPrefabCountInScene; i++)
        {

            Vector3 randomPoint = Random.onUnitSphere * worldSphereRadius;

            Instantiate(prefab.transform, randomPoint, Quaternion.identity, null);

            currentPrefabCountInScene++;

        }
    }
}
