using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnblockDoorOnEnable : MonoBehaviour
{
    [SerializeField] private RoomDoorBlocker _doorToToggle;
    [SerializeField] private bool _state;
    private void OnEnable()
    {
        _doorToToggle.CanPlayerLeaveRoom(_state);
    }
}
