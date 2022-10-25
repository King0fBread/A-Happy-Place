using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleItemsUse : MonoBehaviour
{
    //items to toggle
    [SerializeField] private FlashlightLogic _flashlightLogic;
    [SerializeField] private PhoneToggleButton _phoneToggleButton;

    private bool _canPhoneBeUsed;
    public void ToggleFlashlightState(bool value)
    {
        _flashlightLogic.TryForceToogleFlashlight(value);
    }
    public void ToggleFlashlightPermission(bool value)
    {
        _flashlightLogic.ToggleFlashlightPermisson(value);
    }
    public void ManuallyDisablePhone()
    {
        _canPhoneBeUsed = _phoneToggleButton.IsPhoneActive();
        _phoneToggleButton.gameObject.SetActive(false);
    }
    public void TryManuallyEnablePhone()
    {
        if (_canPhoneBeUsed) _phoneToggleButton.gameObject.SetActive(true);
    }
}
