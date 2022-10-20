using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleItemsUse : MonoBehaviour
{
    //items to toggle
    [SerializeField] private FlashlightLogic _flashlightLogic;
    [SerializeField] private PhoneToggleButton _phoneToggleButton;
    public void CanUseFlashlight(bool state)
    {
        _flashlightLogic.AllowFlashlightUse(state);
    }
    public void CanUsePhone(bool state)
    {
        _phoneToggleButton.gameObject.SetActive(state);
    }
}
