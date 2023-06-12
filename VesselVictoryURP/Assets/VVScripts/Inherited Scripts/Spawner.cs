using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] protected GameObject prefabToSpawn; 
    [SerializeField] protected GameObject worldSphere; 
    [SerializeField] protected int maximumPrefabCountInScene = 3;
    [SerializeField] protected float minSpawnDelay, maxSpawnDelay;

    protected int currentPrefabCountInScene = 0;
    
    public static Spawner Instance;
    private void Awake()
    {
        if (Instance == null)
        { Instance = this; }
        
    }
    private void Update()
    {
        StartCoroutine(SpawnPrefabsCoroutine(prefabToSpawn));
    }
    protected virtual void LegacySpawnPrefabs(GameObject prefab)
    {
        float worldSphereRadius = worldSphere.transform.localScale.x / 2f;

        for (int i = 0; currentPrefabCountInScene < maximumPrefabCountInScene; i++)
        {
            Vector3 randomPoint = Random.onUnitSphere * worldSphereRadius;

            Instantiate(prefab.transform, randomPoint, Quaternion.identity, null);

            currentPrefabCountInScene++;

        }
    }
    protected virtual IEnumerator SpawnPrefabsCoroutine(GameObject prefab)
    {
        float worldSphereRadius = worldSphere.transform.localScale.x / 2f;

            for (int i = 0; currentPrefabCountInScene < maximumPrefabCountInScene; i++)
            {
                currentPrefabCountInScene++;
                yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
                Vector3 randomPoint = Random.onUnitSphere * worldSphereRadius;
                Instantiate(prefab.transform, randomPoint, Quaternion.identity, null);
                
            }
        
    }
    public virtual int getCurrentPrefabCountsInScene()  { return currentPrefabCountInScene; }
    public virtual void setCurrentPrefabCountsInScene(int i) { currentPrefabCountInScene = i; }
}
