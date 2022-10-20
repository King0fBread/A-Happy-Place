using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRoomDoorBlocker : MonoBehaviour
{
    [SerializeField] private ToggleItemsUse _itemsToggle;
    private bool _hasPlayerTriedToLeave = false;
    private void OnEnable()
    {
        _hasPlayerTriedToLeave = false;
    }
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
        if (!_hasPlayerTriedToLeave)
        {
            _hasPlayerTriedToLeave = true;
            print("cant go");
            //sound of not wanting to leave
        }
    }
}
