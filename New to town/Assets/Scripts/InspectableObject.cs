using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InspectableObject : MonoBehaviour
{
    [SerializeField] private GameObject[] _inspectableObjects;
    [SerializeField] private Transform _inspectionTransform;

    [SerializeField] private Button _escapeButton;
    [SerializeField] private Button _nextObjectButton;

    [SerializeField] private GameObject _inspectionAvailableObject;
    private int _currentObjectIndex = 0;

    private void OnMouseEnter()
    {
        _inspectionAvailableObject.SetActive(true);
    }
    private void OnMouseExit()
    {
        _inspectionAvailableObject.SetActive(false);
    }
    private void OnMouseDown()
    {
        if (_inspectableObjects.Length > 1)
        {
            _nextObjectButton.gameObject.SetActive(true);
            _nextObjectButton.onClick.AddListener(InspectObject);
        }
        _escapeButton.gameObject.SetActive(true);
        _escapeButton.onClick.AddListener(QuitInspection);

        InspectObject();
    }
    private void InspectObject()
    {
        _inspectionAvailableObject.SetActive(false);

        if (_currentObjectIndex > _inspectableObjects.Length - 1) _currentObjectIndex = 0;

        _inspectableObjects[_currentObjectIndex].transform.position = _inspectionTransform.position;
        _inspectableObjects[_currentObjectIndex].transform.rotation = _inspectionTransform.rotation;
        _currentObjectIndex++;
    }
    private void QuitInspection()
    {
        _currentObjectIndex = 0;
        if(_nextObjectButton.gameObject.activeSelf) _nextObjectButton.onClick.RemoveListener(InspectObject);
        _escapeButton.onClick.RemoveListener(QuitInspection);

        _nextObjectButton.gameObject.SetActive(false);
        _escapeButton.gameObject.SetActive(false);
        //disable objects under inspection (destroy or set false (?))

    }
}
