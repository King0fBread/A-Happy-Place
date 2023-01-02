using System;
using UnityEngine;

public class FlashlightLogic : MonoBehaviour
{
    [SerializeField] private MovementEventsManager _eventsManager;
    [SerializeField] private GameObject _lightSource;
    [SerializeField] private bool _flashlightCanBeUsed = false;
    private bool _flashlightCurrentState = false;
    private bool _flashlightWasTemporarilyDisabled;

    private void Awake()
    {
        _eventsManager.OnLeftMouseButtonPressed += UseFlashlight;
    }
    private void UseFlashlight(object sender, EventArgs args)
    {
        if (_flashlightCanBeUsed)
        {
            _lightSource.SetActive(!_flashlightCurrentState);
            _flashlightCurrentState = !_flashlightCurrentState;

            //interrupting the previous click to correctly play the sound
            SoundsManager.instance.StopSound(SoundsManager.Sounds.PlayerFlashlight);
            SoundsManager.instance.PlaySound(SoundsManager.Sounds.PlayerFlashlight);
        }
    }
    public void AllowFlashlightUse(bool value)
    {
        _flashlightCanBeUsed = value;
    }
    public void TryForceToogleFlashlight(bool valueToToggle)
    {
        if (_flashlightCanBeUsed && _flashlightCurrentState==!valueToToggle)
        {
            _lightSource.SetActive(valueToToggle);
            _flashlightCurrentState = valueToToggle;
        }
    }
    public void ToggleFlashlightPermisson(bool value)
    {
        if(_flashlightCanBeUsed && value == false)
        {
            _flashlightCanBeUsed = value;
            _flashlightWasTemporarilyDisabled = true;
        }
        else if(!_flashlightCanBeUsed && value == true && _flashlightWasTemporarilyDisabled)
        {
            _flashlightCanBeUsed = value;
            _flashlightWasTemporarilyDisabled = false;
        }
    }
}
