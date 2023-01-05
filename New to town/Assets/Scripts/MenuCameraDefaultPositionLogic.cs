using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCameraDefaultPositionLogic : MonoBehaviour
{
    public bool cameraIsNotFocused { get; set; }
    [SerializeField] private GameObject _resetButtonObject;
    private Vector3 _defaultCamPosition;
    private Quaternion _defaultCamRotation;
    private void Awake()
    {
        _defaultCamPosition = transform.position;
        _defaultCamRotation = transform.rotation;
        cameraIsNotFocused = true;

        _resetButtonObject.SetActive(false);
    }
    public void ResetCamPosition()
    {
        transform.position = _defaultCamPosition;
        transform.rotation = _defaultCamRotation;
        cameraIsNotFocused = true;

        _resetButtonObject.SetActive(false);
    }
}
