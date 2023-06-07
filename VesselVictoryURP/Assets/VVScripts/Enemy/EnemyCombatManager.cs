using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombatManager : MonoBehaviour
{
    private EnemyShipStats enemyStats;

    [SerializeField] private CannonBallPass projectileStats;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float cannonDelayMinF, cannonDelayMaxF;
    [SerializeField] public GameObject collisionFX;

    private GameObject player;
    private Transform playerTransform;

    private const float DEFAULT_PROJECTILE_SPEED = 2.5f;
    private const float DEFAULT_CANNON_RANGE = 8f;

    private float thisShipHealth;
    private float projectileDamage;
    private float cannonOffset = 0.8f;
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
    private Vector3 CannonFireOffset(Vector3 baseVector)
    {
        float offsetX = Random.Range(-cannonOffset, cannonOffset);
        float offsetZ = Random.Range(-cannonOffset, cannonOffset);

        Vector3 offsetPosition = new Vector3(offsetX, offsetZ);
        Vector3 finalPosition = baseVector + offsetPosition;

        return finalPosition;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("PlayerProjectiles"))
        {
            Instantiate(collisionFX, transform.position, transform.rotation);
            enemyStats.setEnemyShipHealth(thisShipHealth - projectileDamage);
        }  
    }
    private void FireEnemyCannon()
    {
        float distanceFromPlayer = Vector3.Distance(transform.position, playerTransform.position);

        if (distanceFromPlayer <= DEFAULT_CANNON_RANGE)
        {
            Vector3 currentPlayerPosition = (playerTransform.position - spawnPoint.position).normalized;
            Vector3 playerOffsetPosition = CannonFireOffset(currentPlayerPosition);

            GameObject spawnedProjectile = Instantiate(projectilePrefab, spawnPoint.position, spawnPoint.rotation);
            Rigidbody projectileRigidBody = spawnedProjectile.GetComponent<Rigidbody>();

            spawnPoint.LookAt(playerTransform);
            projectileRigidBody.velocity = (playerOffsetPosition) * DEFAULT_PROJECTILE_SPEED;
        }
    }
    //Patchwork bug fix to stop all cannons from firing upon 
    IEnumerator DelayedFireEnemyCannon()
    {
        while (true) 
        {
            float delay = Random.Range(cannonDelayMinF, cannonDelayMaxF);
            yield return new WaitForSeconds(delay);
            FireEnemyCannon();
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, DEFAULT_CANNON_RANGE);
    }
}
