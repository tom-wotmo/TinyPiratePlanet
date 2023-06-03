using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombatManager : MonoBehaviour
{
    private EnemyShipStats enemyStats;
    [SerializeField] private CannonBallPass projectileStats;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float projectileSpeed = 10f;
    [SerializeField] private float cannonRange = 0f;
    [SerializeField] private float cannonDelayMinF, cannonDelayMaxF;
    private GameObject player;
    private Transform playerTransform;
   
    private float thisShipHealth;
    private float projectileDamage;
    private void Start()
    {
        enemyStats = GetComponent<EnemyShipStats>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerTransform = player.transform;
        StartCoroutine(DelayedFireEnemyCannon());
    }
    private void Update()
    {
        thisShipHealth = enemyStats.getEnemyShipHealth();
        projectileDamage = projectileStats.getProjectileDamage();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("PlayerProjectiles")){ enemyStats.setEnemyShipHealth(thisShipHealth - projectileDamage);}
    }
    private void FireEnemyCannon()
    {
        float distanceFromPlayer = Vector3.Distance(transform.position, playerTransform.position);

        if (distanceFromPlayer <= cannonRange)
        {
            Vector3 playerPosition = (playerTransform.position - spawnPoint.position).normalized;
            GameObject spawnedProjectile = Instantiate(projectilePrefab, spawnPoint.position, spawnPoint.rotation);
            Rigidbody projectileRigidBody = spawnedProjectile.GetComponent<Rigidbody>();
            spawnPoint.LookAt(playerTransform);
            projectileRigidBody.velocity = playerPosition * projectileSpeed;
        }
    }
    IEnumerator DelayedFireEnemyCannon()
    {
        while (true) //delaying the triple fire from all 3 boats upon spawn
        {
            float delay = Random.Range(cannonDelayMinF, cannonDelayMaxF);
            yield return new WaitForSeconds(delay);
            FireEnemyCannon();
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, cannonRange);
    }
}
