using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhoneToggleButton : MonoBehaviour
{
    [SerializeField] private GameObject _phoneObject;
    [SerializeField] private MovementEventsManager _eventsManager;
    [SerializeField] private GameObject _crossHair;
    [SerializeField] private PlayerMovement _playerMovement;
    private Image thisImage;
    private bool _isActive = false;
    private bool _canUsePhone = false;
    private Color _fullyVisibleButton = new Color(1f, 1f, 1f, 1f);
    private Color _inactiveButton = new Color(1f, 1f, 1f, 0.3f);
    private void Awake()
    {
        thisImage = GetComponent<Image>();
        _eventsManager.OnEKeyPressed += ToggleAlphaAndPhone;
        gameObject.SetActive(false);
    }
    private void OnEnable()
    {
        _canUsePhone = true;
    }
    public void ToggleAlphaAndPhone(object sender, EventArgs args)
    {
        if (_canUsePhone)
        {
            _isActive = !_isActive;
            //phone is opened
            if (_isActive)
            {
                _phoneObject.SetActive(true);
                thisImage.color = _inactiveButton;
                Cursor.lockState = CursorLockMode.None;
                _playerMovement.TogglePlayerRotaion(false);
                _crossHair.SetActive(false);
            }
            //phone is closed
            else if (!_isActive)
            {
                _phoneObject.SetActive(false);
                thisImage.color = _fullyVisibleButton;
                Cursor.lockState = CursorLockMode.Locked;
                _playerMovement.TogglePlayerRotaion(true);
                _crossHair.SetActive(true);
            }
        }
    }
    public bool IsPhoneActive()
    {
        return _canUsePhone;
    }
}
