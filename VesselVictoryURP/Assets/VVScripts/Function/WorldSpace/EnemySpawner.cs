using UnityEngine;

public class EnemySpawner : Spawner
{
    
    [SerializeField] private int activeEnemiesInSceneAtOnce = 3;
   
    private int activePrefabsInScene = 0;

    private void Update()
    {
        if(Time.time >= 3f) { spawnPrefabs(prefabToSpawn); }
        
    }
    protected override void spawnPrefabs(GameObject prefab)
    {
        float worldSphereRadius = worldSphere.transform.localScale.x / 2f;
       
        for (int i = 0; activePrefabsInScene < activeEnemiesInSceneAtOnce; i++)
        {
            Vector3 randomPoint = Random.onUnitSphere * worldSphereRadius;

            Instantiate(prefab.transform, randomPoint, Quaternion.identity, null);

            activePrefabsInScene++;

        }
    }
}
  
 

