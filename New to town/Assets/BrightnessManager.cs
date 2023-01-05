using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;

public class BrightnessManager : MonoBehaviour
{
    [SerializeField] private PostProcessProfile _ppProfile;
    private AutoExposure _exposure;
    private Slider _brightnessSlider;
    private float _brightnessValue;
    private void Awake()
    {
        _brightnessSlider = GetComponent<Slider>();
        _ppProfile.TryGetSettings(out _exposure);
        _brightnessValue = PlayerPrefs.GetFloat("Brightness",1);

        _exposure.keyValue.value = _brightnessValue;
        _brightnessSlider.value = _brightnessValue;
    }
    public void ChangeBrightness()
    {
        _brightnessValue = _brightnessSlider.value;
        _exposure.keyValue.value = _brightnessValue;
        PlayerPrefs.SetFloat("Brightness", _brightnessValue);
    }
}
