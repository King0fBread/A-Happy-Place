using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnblockDoorOnEnable : MonoBehaviour
{
    [SerializeField] private RoomDoorBlocker _doorToUnlock;
    [SerializeField] private bool _state;
    private void OnEnable()
    {
        _doorToUnlock.CanPlayerLeaveRoom(_state);
    }
}
