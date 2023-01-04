using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuTeleportationLogic : MonoBehaviour
{
    [SerializeField] private GameObject _interactionObj;
    [SerializeField] private GameObject _cameraObj;
    [SerializeField] private GameObject _cameraResetButton;

    [SerializeField] private Transform _newCameraLocation;
    private void OnMouseDown()
    {
        _cameraResetButton.SetActive(true);

        _cameraObj.transform.position = _newCameraLocation.position;
        _cameraObj.transform.rotation = _newCameraLocation.rotation;
    }
}
