using UnityEngine;

public class RoomDoorBlocker : MonoBehaviour
{
    [SerializeField] private ToggleItemsUse _itemsToggle;
    [SerializeField] private Transform _outsideDoorPoint;
    [SerializeField] private Transform _insideDoorPoint;
    [SerializeField] private GameObject _playerObject;
    [SerializeField] private bool _isPlayerInside = true;
    [SerializeField] private bool _canGoBack = true;
    [SerializeField] private bool _isMetalDoor = false;
    private bool _enteredOneWayRoom = false;
    private bool _canCurrentlyLeaveRoom = false;
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
        if (_enteredOneWayRoom) return;

        if (!_canCurrentlyLeaveRoom)
        {
            print("cant go");
        }
        else if (_canCurrentlyLeaveRoom)
        {
            if (!_canGoBack) _enteredOneWayRoom = true;

            if (_isPlayerInside) ChangePosition(_outsideDoorPoint);
            else if (!_isPlayerInside) ChangePosition(_insideDoorPoint);

            if (_isMetalDoor)
            {
                SoundsManager.instance.PlaySound(SoundsManager.Sounds.EnvironmentMetalDoorOpens);
            }
            else
            {
                SoundsManager.instance.PlaySound(SoundsManager.Sounds.EnvironmentDoorOpens);
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
        _canCurrentlyLeaveRoom = canLeave;
    }
}
