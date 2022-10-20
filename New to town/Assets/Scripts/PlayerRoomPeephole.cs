using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRoomPeephole : MonoBehaviour
{
    [SerializeField] private GameObject _peepCamera;
    [SerializeField] private ToggleItemsUse _itemsToggle;
    private void OnMouseDown()
    {
        _peepCamera.SetActive(true);

        _itemsToggle.CanUseFlashlight(false);
        _itemsToggle.CanUsePhone(false);
    }
    private void OnMouseUp()
    {
        _peepCamera.SetActive(false);

        _itemsToggle.CanUseFlashlight(true);
        _itemsToggle.CanUsePhone(true);
    }
}
