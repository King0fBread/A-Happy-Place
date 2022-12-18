using UnityEngine;

public class RoomDoorBlocker : MonoBehaviour
{
    [SerializeField] private ToggleItemsUse _itemsToggle;
    [SerializeField] private Transform _outsideDoorPoint;
    [SerializeField] private Transform _insideDoorPoint;
    [SerializeField] private GameObject _playerObject;
    [SerializeField] private bool _isPlayerInside = true;
    private bool _canLeaveRoom = false;
    private void OnMouseEnter()
    {
        _itemsToggle.ToggleFlashlightPermission(false);
    }
    private void OnMouseExit()
    {
        _itemsToggle.ToggleFlashlightPermission(true);
    }
    private void OnMouseDown()
    {
        if (!_canLeaveRoom)
        {
            print("cant go");
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
    public void CanPlayerLeaveRoom(bool canLeave)
    {
        _canLeaveRoom = canLeave;
    }
}
