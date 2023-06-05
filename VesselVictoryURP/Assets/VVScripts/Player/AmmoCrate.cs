
using UnityEngine;

public class AmmoCrate : MonoBehaviour
{
    [SerializeField] private float ammoCrateAmmoCapacity = 3f;
    private PlayerShipStats ship; 

    private float currentShipAmmo;
    private void Start()
    {
        ship = FindObjectOfType<PlayerShipStats>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("PlayerBoat"))
        {
            currentShipAmmo = ship.getPlayerShipAmmo();
            ship.setPlayerShipAmmo(currentShipAmmo + ammoCrateAmmoCapacity);
            Debug.Log(ship.getPlayerShipAmmo());
            Destroy(gameObject);
        }
        
    }
   
}
