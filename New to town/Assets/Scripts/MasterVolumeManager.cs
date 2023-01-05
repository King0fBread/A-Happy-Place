using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MasterVolumeManager : MonoBehaviour
{
    [SerializeField] private AudioMixer _masterMixer;
    private Slider _slider;
    private float _soundVolume;
    private void Awake()
    {
        _slider = GetComponent<Slider>();
        _soundVolume = PlayerPrefs.GetFloat("MasterVolume", 0);

        _masterMixer.SetFloat("MasterVolume", _soundVolume);
        _slider.value = _soundVolume;
    }

    public void ChangeMasterVolume()
    {
        _soundVolume = _slider.value;
        _masterMixer.SetFloat("MasterVolume", _soundVolume);
        PlayerPrefs.SetFloat("MasterVolume", _soundVolume);
    }
}
