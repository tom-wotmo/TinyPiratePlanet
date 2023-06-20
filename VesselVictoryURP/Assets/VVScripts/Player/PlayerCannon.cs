using UnityEngine;
using System.Collections;
public class PlayerCannon : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform rightSpawnPoint;
    [SerializeField] private Transform leftSpawnPoint;
    [SerializeField] private float projectileSpeed = 10f;
    [SerializeField] private AudioClip fireClip;

    private float boatAmmo;
    private PlayerShipStats ship;

    private KeyCode rightCannonFireKey = KeyCode.E;
    private KeyCode leftCannonFireKey = KeyCode.Q;

    private void Start()
    {
        ship = GetComponent<PlayerShipStats>();
    }
    
    void Update()
    {
        CannonFireControls();
    }
    private void FireCannon(Transform firingPoint)
    {
        GameObject spawnedProjectile = Instantiate(projectilePrefab, firingPoint.position, firingPoint.rotation);
        Rigidbody projectileRigidBody = spawnedProjectile.GetComponent<Rigidbody>();
        projectileRigidBody.velocity = firingPoint.forward * projectileSpeed;
    }
    private void CannonFireControls()
    {
        boatAmmo = ship.getPlayerShipAmmo();

        if (Input.GetKeyDown(rightCannonFireKey) && boatAmmo > 0)
        {
            FireCannon(rightSpawnPoint);
            ship.setPlayerShipAmmo(boatAmmo - 1);
            AudioManager.Instance.PlayOneShotSpatialSound(fireClip, 0.5f, 1f);

        }
        if (Input.GetKeyDown(leftCannonFireKey) && boatAmmo > 0)
        {
            FireCannon(leftSpawnPoint);
            ship.setPlayerShipAmmo(boatAmmo - 1);
            AudioManager.Instance.PlayOneShotSpatialSound(fireClip, 0.5f, -1f);
        }
        else if (boatAmmo <= 0)
        {
            return;
        }
    }
    
}
