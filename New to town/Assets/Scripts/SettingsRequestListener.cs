using System;
using UnityEngine;

public class SettingsRequestListener : MonoBehaviour
{
    [SerializeField] private MovementEventsManager _eventsManager;
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private FlashlightLogic _flashlightLogic;
    [SerializeField] private GameObject _settingsObj;
    [SerializeField] private GameObject _settingsIcon;
    private bool _firstToggle = true;
    private bool _currentInteractionsActivityState;
    private void Awake()
    {
        _eventsManager.OnEscPressed += ToggleSettings;
    }
    private void ToggleSettings(object sender, EventArgs args)
    {
        if (_firstToggle)
        {
            Destroy(_settingsIcon);
            _firstToggle = false;
        }
        _settingsObj.SetActive(!_settingsObj.activeSelf);
        _currentInteractionsActivityState = !_settingsObj.activeSelf;

        _playerMovement.TogglePlayerMovement(_currentInteractionsActivityState);
        _playerMovement.TogglePlayerRotaion(_currentInteractionsActivityState);
        _flashlightLogic.ToggleFlashlightPermisson(_currentInteractionsActivityState);

        if (_currentInteractionsActivityState == false) Cursor.lockState = CursorLockMode.None;
        else Cursor.lockState = CursorLockMode.Locked;
    }
    private void OnDestroy()
    {
        _eventsManager.OnEscPressed -= ToggleSettings;
    }
}
