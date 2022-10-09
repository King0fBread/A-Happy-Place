using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightLogic : MonoBehaviour
{
    [SerializeField] private EventsManager _eventsManager;
    [SerializeField] private GameObject _lightSource;
    private bool _flashlightPickedUp = false;
    private bool _flashlightCurrentState = false;

    private void Awake()
    {
        _eventsManager.OnLeftMouseButtonPressed += UseFlashlight;
    }
    private void UseFlashlight(object sender, EventArgs args)
    {
        if (_flashlightPickedUp)
        {
            _lightSource.SetActive(!_flashlightCurrentState);
            _flashlightCurrentState = !_flashlightCurrentState;
        }
    }
    public void AllowFlashlightUse()
    {
        _flashlightPickedUp = true;
    }
}
