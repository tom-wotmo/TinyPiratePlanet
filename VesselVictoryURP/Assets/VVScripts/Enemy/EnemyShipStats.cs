using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipStats : Stats
{
    private float health;
    private int id;
    private int currentPrefabsInScene;

    private int currentScore;
    [SerializeField] private int awardedScoreForKill;

    
 
    private void Start()
    {
        health = DEFAULT_MAXIMUM_HEALTH;
        id = DEFAULT_ID;
        shipName = "enemyShip";
    }
    private void Update()
    {
        Death();
    }
    public override void Death()
    {
        if (health <= DEFAULT_MINIMUM_HEALTH)
        {
            currentScore = ScoreHandler.Instance.getPlayerScore();
            ScoreHandler.Instance.setPlayerScore(currentScore + awardedScoreForKill);
            currentPrefabsInScene = EnemySpawner.Instance.getCurrentPrefabCountsInScene();
            EnemySpawner.Instance.setCurrentPrefabCountsInScene(currentPrefabsInScene - 1);
   
            Destroy(this.gameObject);
        }
    }
    public float getEnemyShipHealth() { return health; }
    public void setEnemyShipHealth(float i) { health = i; }
    public void setEnemyShipId(int i) { id = i; }



}
