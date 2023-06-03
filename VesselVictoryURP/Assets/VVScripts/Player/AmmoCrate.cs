
using UnityEngine;

public class AmmoCrate : MonoBehaviour
{
    [SerializeField] private float ammoCrateAmmoCapacity = 3f;
    [SerializeField] private PlayerShipStats ship;
    
    private void OnTriggerEnter(Collider other)
    {
        ship.setPlayerShipAmmo(ammoCrateAmmoCapacity);
        Debug.Log(ship.getPlayerShipAmmo());

        Destroy(gameObject);
    }
   
}
