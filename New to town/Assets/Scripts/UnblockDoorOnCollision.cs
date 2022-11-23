using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnblockDoorOnCollision : MonoBehaviour
{
    [SerializeField] private RoomDoorBlocker _doorToToggle;
    [SerializeField] private bool _state;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _doorToToggle.CanPlayerLeaveRoom(_state);
        }
    }
}
