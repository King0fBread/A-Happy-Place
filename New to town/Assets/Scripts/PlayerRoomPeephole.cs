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

        _itemsToggle.ToggleFlashlightState(false);
        _itemsToggle.ToggleFlashlightPermission(false);
        _itemsToggle.ManuallyDisablePhone();
    }
    private void OnMouseUp()
    {
        _peepCamera.SetActive(false);

        _itemsToggle.ToggleFlashlightPermission(true);
        _itemsToggle.TryManuallyEnablePhone();
    }
}
