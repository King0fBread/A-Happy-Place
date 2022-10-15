using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ControllCinemachineShake : MonoBehaviour
{
    public float _runningShakeIntensity;
    public float _walkingShakeIntensity;
    public float _idleShakeIntensity;
    private CinemachineVirtualCamera _cinemachineVirtualCamera;
    private void Awake()
    {
        _cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();
    }
    public void StartShake(float intensity)
    {
        CinemachineBasicMultiChannelPerlin _cinemachineBasicMultiChannelPerlin =
            _cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        _cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = intensity;
    }
}
