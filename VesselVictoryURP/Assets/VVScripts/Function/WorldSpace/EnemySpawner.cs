using UnityEngine;

public class EnemySpawner : Spawner
{
    public static EnemySpawner Instance;
    private void Awake()
    {
        if (Instance == null)
        { Instance = this; }

    }
    private void Update()
    {
        if(Time.time >= 3f) { spawnPrefabs(prefabToSpawn); }
    }
    protected override void spawnPrefabs(GameObject prefab)
    {
        float worldSphereRadius = worldSphere.transform.localScale.x / 2f;
       
        for (int i = 0; currentPrefabCountInScene < maximumPrefabCountInScene; i++)
        {
            Vector3 randomPoint = Random.onUnitSphere * worldSphereRadius;

            Instantiate(prefab.transform, randomPoint, Quaternion.identity, null);

            currentPrefabCountInScene++;

        }
    }
    public override int getCurrentPrefabCountsInScene() { return currentPrefabCountInScene; }
    public override void setCurrentPrefabCountsInScene(int i) { currentPrefabCountInScene = i; }

}
  
 

