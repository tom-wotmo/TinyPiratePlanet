using UnityEngine;
using System.Collections;
public class PlayerCannon : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float projectileSpeed = 10f;
    private float boatAmmo;
    private ShipStats ship;
    private KeyCode cannonFireKey = KeyCode.Space;

    private void Start()
    {
        ship = GetComponent<ShipStats>();
    }
    public void FireCannon()
    {
        GameObject spawnedProjectile = Instantiate(projectilePrefab, spawnPoint.position, spawnPoint.rotation);
        Rigidbody projectileRigidBody = spawnedProjectile.GetComponent<Rigidbody>();
        projectileRigidBody.velocity = spawnPoint.forward * projectileSpeed;

       
    }

    void Update()
    {
        boatAmmo = ship.getShipAmmo();

        if (Input.GetKeyDown(cannonFireKey) && boatAmmo > 0)
        {
            FireCannon();
            ship.setShipAmmo(boatAmmo - 1);
          

        }
        else if(boatAmmo <= 0)
        {
            Debug.Log("Can't fire");
        }
      
    }
    
}
