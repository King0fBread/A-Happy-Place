using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundsManager : MonoBehaviour
{
    [SerializeField] private AudioMixer _gameAudioMixer;

    private static SoundsManager _instance;
    public static SoundsManager instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }
    }
    public void ChangeMasterVolume(int newMasterVolumeValue)
    {
        _gameAudioMixer.SetFloat("MasterVolume", newMasterVolumeValue);
    }

    public enum Sounds
    {
        EnvironmentBed,
        EnvironmentDoorOpens,
        EnvironmentMetalDoorOpens,
        EnvironmentPickupItem,
        EnvironmentStudying,
        PhoneMessageRecieved,
        PhoneMessageSent,
        PlayerFlashlight,
        PlayerFootstepsRunning,
        PlayerFootstepsWalkingConcrete,
        PlayerFootstepsWalkingWood,
        EnvironmentDoorLockUnlocked,
        EnvironmentTVStatic,
        MonsterOneBreath,
        MonsterQuietGrowl,
        MonsterGrowl,
        MonsterWindowKnock,
    }
    public void PlaySound(Sounds soundToPlay2D)
    {
        //reference the appropriate class
    }
    public void PlaySound(Sounds soundToPlay3D, AudioSource soundAudioSource3D)
    {
        //yuh
    }

    public SoundAudioClip[] soundAudioClipsArray;
    [System.Serializable]
    public class SoundAudioClip 
    {
        public Sounds sound;
        public AudioClip clip;
    }


}
