using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSlowDown : MonoBehaviour
{
    private float playerBoatSpeed;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("PlayerBoat"))
        {
            playerBoatSpeed = PlayerController.Instance.getPlayerControllerMoveSpeed();
            PlayerController.Instance.setPlayerControllerMoveSpeed(playerBoatSpeed / 2);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("PlayerBoat"))
        {
            playerBoatSpeed = PlayerController.Instance.getPlayerControllerMoveSpeed();
            PlayerController.Instance.setPlayerControllerMoveSpeed(playerBoatSpeed * 2);
        }

    }
}
