using UnityEngine;
using System.Collections;
public class PlayerCannon : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform rightSpawnPoint;
    [SerializeField] private Transform leftSpawnPoint;
    [SerializeField] private float projectileSpeed = 10f;
    private float boatAmmo;
    private ShipStats ship;
    private KeyCode rightCannonFireKey = KeyCode.E;
    private KeyCode leftCannonFireKey = KeyCode.Q;

    private void Start()
    {
        ship = GetComponent<ShipStats>();
    }
    //probably merge this into one script with method params
    public void FireRightCannon()
    {
        GameObject spawnedProjectile = Instantiate(projectilePrefab, rightSpawnPoint.position, rightSpawnPoint.rotation);
        Rigidbody projectileRigidBody = spawnedProjectile.GetComponent<Rigidbody>();
        projectileRigidBody.velocity = rightSpawnPoint.forward * projectileSpeed;
       
    }
    public void FireLeftCannon()
    {
        GameObject spawnedProjectile = Instantiate(projectilePrefab, leftSpawnPoint.position, leftSpawnPoint.rotation);
        Rigidbody projectileRigidBody = spawnedProjectile.GetComponent<Rigidbody>();
        projectileRigidBody.velocity = leftSpawnPoint.forward * projectileSpeed;
    }

    void Update()
    {
        boatAmmo = ship.getShipAmmo();

        if (Input.GetKeyDown(rightCannonFireKey) && boatAmmo > 0)
        {
            FireRightCannon();
            ship.setShipAmmo(boatAmmo - 1);

        }
        if(Input.GetKeyDown(leftCannonFireKey)&& boatAmmo > 0)
        {
            FireLeftCannon();
            ship.setShipAmmo(boatAmmo - 1);
        }
        else if(boatAmmo <= 0)
        {
            return;
        }
      
    }
    
}
