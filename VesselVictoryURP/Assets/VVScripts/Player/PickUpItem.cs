using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PickUpItem : MonoBehaviour
{
    
    [SerializeField]
    private PickUpOptions selectedOption;

    [SerializeField]
    [Tooltip("Value for the item the player is picking up, health, ammo etc.")] 
    private float pickUpItemValue;

    private PlayerShipStats ship;
    private int currentPrefabsInScene;
    private float currentItemCount;

    [SerializeField] private AudioClip pickUpSFX;
    public enum PickUpOptions
    {
        Ammo,
        Health
    }

    private void Start()
    {
        ship = FindObjectOfType<PlayerShipStats>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("PlayerBoat") && (selectedOption.ToString() == "Ammo"))
        {
            PickUpAmmoCrate();
        }
        else if (other.gameObject.layer == LayerMask.NameToLayer("PlayerBoat") && (selectedOption.ToString() == "Health"))
        {
            PickUpHealthShip();
        }
    }
    private void PickUpAmmoCrate()
    {
        currentItemCount = ship.getPlayerShipAmmo();
        ship.setPlayerShipAmmo(currentItemCount + pickUpItemValue);
        currentPrefabsInScene = CrateSpawner.Instance.getCurrentPrefabCountsInScene();
        CrateSpawner.Instance.setCurrentPrefabCountsInScene(currentPrefabsInScene - 1);
        AudioManager.Instance.PlayOneShotSound(pickUpSFX, 1f);
        Destroy(gameObject);
    }
    private void PickUpHealthShip()
    {
        currentItemCount = ship.getPlayerShipHealth();
        ship.setPlayerShipHealth(currentItemCount + pickUpItemValue);
        currentPrefabsInScene = HealthBoatSpawner.Instance.getCurrentPrefabCountsInScene();
        HealthBoatSpawner.Instance.setCurrentPrefabCountsInScene(currentPrefabsInScene - 1);
        AudioManager.Instance.PlayOneShotSound(pickUpSFX, 5f);
        Destroy(gameObject);
    }
  
}
