using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeighborDoorLogic : MonoBehaviour
{
    [SerializeField] private RoomDoorBlocker _neighborDoorBlocker;
    //audio
    private bool _playerCameToTheDoorFirstTime = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _playerCameToTheDoorFirstTime = !_playerCameToTheDoorFirstTime;

            if (_playerCameToTheDoorFirstTime)
            {
                //first opening sound
                _neighborDoorBlocker.CanPlayerLeaveRoom(true);
            }
            else
            {
                //closing sound when player runs away
            }
            gameObject.SetActive(false);
        }
    }
}
