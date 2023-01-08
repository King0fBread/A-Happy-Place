using UnityEngine;
using Cinemachine;

public class ControllCinemachineShake : MonoBehaviour
{
    [SerializeField] private float _shakeInterpolationIntensity;
    public float _runningShakeIntensity;
    public float _walkingShakeIntensity;
    public float _idleShakeIntensity;
    private CinemachineVirtualCamera _cinemachineVirtualCamera;
    private CinemachineBasicMultiChannelPerlin _cinemachineBasicMultiChannelPerlin;
    private float _currentIntensity;
    private float _requiredIntensity;
    private void Awake()
    {
        _cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();
    }
    public void StartShake(float intensity)
    {
        _cinemachineBasicMultiChannelPerlin = _cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        _currentIntensity = _cinemachineBasicMultiChannelPerlin.m_AmplitudeGain;
        _requiredIntensity = intensity;

        if (_currentIntensity != _requiredIntensity)
        {
            _cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = Mathf.Lerp(_currentIntensity, _requiredIntensity, _shakeInterpolationIntensity);
        }
        else
        {
            _cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = _requiredIntensity;
        }
    }
}
