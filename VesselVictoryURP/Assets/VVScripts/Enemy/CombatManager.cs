using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    private EnemyBoatStats enemyStats;
    [SerializeField] private CannonBallPass projectileStats;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float projectileSpeed = 10f;

    private float thisShipHealth;
    private float projectileDamage;
    private void Start()
    {
        enemyStats = GetComponent<EnemyBoatStats>();

        StartCoroutine(DelayedFireEnemyCannon());
    }
    private void Update()
    {
        thisShipHealth = enemyStats.getEnemyShipHealth();

        projectileDamage = projectileStats.getProjectileDamage();

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("PlayerProjectiles"))
        {
            enemyStats.setEnemyShipHealth(thisShipHealth - projectileDamage);

        }
    }
    private void FireEnemyCannon()
    {
        Vector3 playerPosition = (playerTransform.position - spawnPoint.position).normalized;

        GameObject spawnedProjectile = Instantiate(projectilePrefab, spawnPoint.position, spawnPoint.rotation);
        Rigidbody projectileRigidBody = spawnedProjectile.GetComponent<Rigidbody>();
        spawnPoint.LookAt(playerTransform);
        projectileRigidBody.velocity = playerPosition * projectileSpeed;
    }
    IEnumerator DelayedFireEnemyCannon()
    {
        while (true)
        {
            yield return new WaitForSeconds(5f);
            FireEnemyCannon();
        }
    }
}
