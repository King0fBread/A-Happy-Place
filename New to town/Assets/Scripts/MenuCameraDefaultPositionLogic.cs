using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCameraDefaultPositionLogic : MonoBehaviour
{
    [SerializeField] private Transform _camera;
    private Vector3 _defaultCamPosition;
    private Quaternion _defaultCamRotation;
    private void Awake()
    {
        _defaultCamPosition = _camera.position;
        _defaultCamRotation = _camera.rotation;

        gameObject.SetActive(false);
    }
    public void ResetCamPosition()
    {
        _camera.position = _defaultCamPosition;
        _camera.rotation = _defaultCamRotation;

        gameObject.SetActive(false);
    }
}
