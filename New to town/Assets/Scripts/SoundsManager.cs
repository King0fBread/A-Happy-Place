using UnityEngine;
using UnityEngine.Audio;

public class SoundsManager : MonoBehaviour
{
    [SerializeField] private AudioMixer _gameAudioMixer;
    private AudioSource _audioSource;
    private AudioClip _audioClip;
    public SoundAudioClip[] soundAudioClipsArray;
    [System.Serializable]
    public class SoundAudioClip 
    {
        public Sounds sound;
        public AudioClip clip;
        public AudioSource source;
    }

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
        MonsterDoorKnock,
    }
    public void PlaySound(Sounds soundToPlay)
    {
        GetRequestedAudioClipAndAudioSource(soundToPlay, out _audioSource, out _audioClip);
        if (!_audioSource.isPlaying)
            _audioSource.PlayOneShot(_audioClip);
    }
    public void StopSound(Sounds soundToStop)
    {
        GetRequestedAudioClipAndAudioSource(soundToStop, out _audioSource, out _audioClip);
        _audioSource.Stop();
    }
    private void GetRequestedAudioClipAndAudioSource(Sounds requestedSound, out AudioSource source, out AudioClip clip)
    {
        //Default null values
        clip = null;
        source = null;

        //Checking for a match
        foreach(SoundAudioClip soundAudioClip in soundAudioClipsArray)
        {
            if (soundAudioClip.sound == requestedSound)
            {
                clip = soundAudioClip.clip;
                source = soundAudioClip.source;
            }
        }
    }



}
