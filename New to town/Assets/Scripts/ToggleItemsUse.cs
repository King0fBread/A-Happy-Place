using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleItemsUse : MonoBehaviour
{
    //items to toggle
    [SerializeField] private FlashlightLogic _flashlightLogic;
    [SerializeField] private PhoneToggleButton _phoneToggleButton;

    private bool _canPhoneBeUsed;
    public void CanUseFlashlight(bool state)
    {
        _flashlightLogic.AllowFlashlightUse(state);
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
    public void ManuallyTurnOffFlashlight()
    {
        _flashlightLogic.ForceTurnOffFlashlight();
    }
}
