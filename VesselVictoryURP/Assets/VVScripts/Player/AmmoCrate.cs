
using UnityEngine;

public class AmmoCrate : MonoBehaviour
{
    [SerializeField] private float ammoCrateAmmoCapacity = 3f;
    [SerializeField] private PlayerShipStats ship; 

    private float currentShipAmmo;
    private void Start()
    {
        ship = FindObjectOfType<PlayerShipStats>();
    }
    private void OnTriggerEnter(Collider other)
    {
        currentShipAmmo = ship.getPlayerShipAmmo();
        ship.setPlayerShipAmmo(currentShipAmmo + ammoCrateAmmoCapacity);
        Debug.Log(ship.getPlayerShipAmmo());
        Destroy(gameObject);
    }
   
}
