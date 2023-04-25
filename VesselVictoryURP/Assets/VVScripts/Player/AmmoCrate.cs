
using UnityEngine;

public class AmmoCrate : MonoBehaviour
{
    [SerializeField] private float ammoCrateHoldAmount = 3f;
    [SerializeField] private ShipStats ship;
    
    private void OnTriggerEnter(Collider other)
    {
        ship.setShipAmmo(ammoCrateHoldAmount);
        Debug.Log(ship.getShipAmmo());

        Destroy(gameObject);
    }
   
}
