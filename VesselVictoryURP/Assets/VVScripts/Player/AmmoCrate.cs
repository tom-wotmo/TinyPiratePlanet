
using UnityEngine;

public class AmmoCrate : MonoBehaviour
{
    [SerializeField] private float ammoCrateAmmoCapacity = 3f;
    private PlayerShipStats ship;
    private int currentPrefabsInScene;

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

            currentPrefabsInScene = Spawner.Instance.getCurrentPrefabCountsInScene();
            Spawner.Instance.setCurrentPrefabCountsInScene(currentPrefabsInScene - 1);
      
            Destroy(gameObject);
        }
        
    } 
}
