using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhoneToggleButton : MonoBehaviour
{
    [SerializeField] private GameObject _phoneObject;
    private Image _buttonImage;
    private bool _isActive = false;
    private Color _fullyVisibleButton = new Color(1f, 1f, 1f, 1f);
    private Color _inactiveButton = new Color(1f, 1f, 1f, 0.4f);
    private void Awake()
    {
        _buttonImage = GetComponent<Image>();
    }
    public void ToggleAlphaAndPhone()
    {
        _isActive = !_isActive;
        if (_isActive)
        {
            _phoneObject.SetActive(true);
            _buttonImage.color = _inactiveButton;
        }
        else if (!_isActive)
        {
            _phoneObject.SetActive(false);
            _buttonImage.color = _fullyVisibleButton;
        }
    }
}
