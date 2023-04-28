using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject prefabToSpawn;
    [SerializeField] private GameObject worldSphere;
    [SerializeField] private int activeEnemiesInSceneAtOnce = 3;
   
    private int activePrefabsInScene = 0;
  
    private void Update()
    {
        if(Time.time >= 3f) { spawnEnemyPrefabs(); }
        
    }
    private void spawnEnemyPrefabs()
    {
        float worldSphereRadius = worldSphere.transform.localScale.x / 2f;

        for (int i = 0; i < 1 && activePrefabsInScene < activeEnemiesInSceneAtOnce; i++)
        {
          
            Vector3 randomPoint = Random.onUnitSphere * worldSphereRadius;

            Instantiate(prefabToSpawn.transform, randomPoint, Quaternion.identity, null);

            activePrefabsInScene++;

        }
    }
}
  
 

