using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FullscreenManager : MonoBehaviour
{
    [SerializeField] private Toggle _fullscreenToggle; 
    //1 for On; 2 for Off
    private int _currentValueInInt;
    private bool _currentValueInBool;

    private void Awake()
    {
        _currentValueInInt = PlayerPrefs.GetInt("FullscreenMode", 1);
        SetFullscreenIntToBool();

        _fullscreenToggle.isOn = _currentValueInBool;
    }
    private void SetFullscreenIntToBool()
    {
        _currentValueInBool = _currentValueInInt == 1 ? true : false;
    }
    private void SetFullscreenBoolToInt()
    {
        _currentValueInInt = _currentValueInBool == true ? 1 : 2;
    }
    public void ToggleFullscreen()
    {
        _currentValueInBool = !_currentValueInBool;
        Screen.fullScreen = _currentValueInBool;
        SetFullscreenBoolToInt();
        PlayerPrefs.SetInt("FullscreenMode", _currentValueInInt);
    }
}
