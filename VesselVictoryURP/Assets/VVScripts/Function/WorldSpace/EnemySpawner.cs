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
        StartCoroutine(SpawnPrefabsCoroutine(prefabToSpawn));
    }
   
}
  
