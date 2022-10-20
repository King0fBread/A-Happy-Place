using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhoneToggleButton : MonoBehaviour
{
    [SerializeField] private GameObject _phoneObject;
    [SerializeField] private EventsManager _eventsManager;
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
            if (_isActive)
            {
                _phoneObject.SetActive(true);
                thisImage.color = _inactiveButton;
            }
            else if (!_isActive)
            {
                _phoneObject.SetActive(false);
                thisImage.color = _fullyVisibleButton;
            }
        }
    }
}
