using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SensitivityManager : MonoBehaviour
{
    [SerializeField] private PlayerMovement _playerMovement;
    private Slider _sensitivitySlider;
    private float _sensitivityXY;
    private void Awake()
    {
        _sensitivitySlider = GetComponent<Slider>();
        _sensitivityXY = PlayerPrefs.GetFloat("SensitivityXY",200f);

        _playerMovement.rotationSensitivityX = _sensitivityXY;
        _playerMovement.rotationSetsitivityY = _sensitivityXY;
    }
    public void ChangeSensinitivy()
    {
        if(_sensitivitySlider.value != _sensitivityXY)
        {
            _sensitivityXY = _sensitivitySlider.value;
            PlayerPrefs.SetFloat("SensitivityXY", _sensitivityXY);
            _playerMovement.rotationSensitivityX = _sensitivityXY;
            _playerMovement.rotationSetsitivityY = _sensitivityXY;
        }
    }
}
