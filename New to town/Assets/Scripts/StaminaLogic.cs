using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaLogic : MonoBehaviour
{
    [SerializeField] private Slider _staminaSlider;
    [SerializeField] private float _decreasingStaminaValue;
    [SerializeField] private float _increasingStaminaValue;
    [SerializeField] private float _maxStaminaValue;
    private float _currentStamina;
    private float _currentStaminaValue;
    private bool _canUseStamina = true;
    private void Awake()
    {
        _staminaSlider.maxValue = _maxStaminaValue;
    }
    private void Update()
    {
        _staminaSlider.value = _currentStamina;
        if (_canUseStamina)
        {
            if (Input.GetKey(KeyCode.LeftShift)) DecreaseStamina();
            else IncreaseStamina();
        }
    }
    private void DecreaseStamina()
    {
        if (_currentStamina > 0)
        {
            _currentStamina -= _decreasingStaminaValue * Time.deltaTime;
        }
    }
    private void IncreaseStamina()
    {
        if (_currentStamina < _maxStaminaValue)
        {
            _currentStamina += _decreasingStaminaValue * Time.deltaTime;
        }
    }
}
