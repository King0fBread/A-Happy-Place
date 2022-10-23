using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRoomDoorBlocker : MonoBehaviour
{
    [SerializeField] private ToggleItemsUse _itemsToggle;
    [SerializeField] private Transform _outsideDoorPoint;
    [SerializeField] private Transform _insideDoorPoint;
    [SerializeField] private GameObject _playerObject;
    private bool _canLeaveRoom = true;
    private bool _isPlayerInside = true;
    private void OnMouseEnter()
    {
        _itemsToggle.CanUseFlashlight(false);
    }
    private void OnMouseExit()
    {
        _itemsToggle.CanUseFlashlight(true);
    }
    private void OnMouseDown()
    {
        if (!_canLeaveRoom)
        {
            print("cant go");
            //sound of not wanting to leave
        }
        else if (_canLeaveRoom)
        {
            if (_isPlayerInside)
            {
                ChangePosition(_outsideDoorPoint);
        
            }
            else if (!_isPlayerInside)
            {
                ChangePosition(_insideDoorPoint);
            }
        }
    }
    private void ChangePosition(Transform newTransform)
    {
        _isPlayerInside = !_isPlayerInside;
        _playerObject.transform.position = newTransform.position;
        _playerObject.transform.rotation = newTransform.rotation;
    }
}
