using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InspectableObject : MonoBehaviour
{
    [SerializeField] private GameObject[] _inspectableObjects;

    private InspectionLogic _inspectLogic;
    private Button _nextInspectionObjectButton;
    private Button _escapeButton;

    private bool _severalInspectableObjects;
    private int _currentObjectIndex = 0;
    private void Awake()
    {
        _nextInspectionObjectButton = GameObject.FindGameObjectWithTag("InspectionNextObjButton").GetComponent<Button>();
        _escapeButton = GameObject.FindGameObjectWithTag("InspectionQuitButton").GetComponent<Button>();
        _inspectLogic = GameObject.FindObjectOfType<InspectionLogic>();

        _severalInspectableObjects = _inspectableObjects.Length > 1;
    }

    private void OnMouseEnter()
    {
        _inspectLogic.InspectionAvailable(true);
    }
    private void OnMouseExit()
    {
        _inspectLogic.InspectionAvailable(false);
    }
    private void OnMouseDown()
    {
        _inspectLogic.DisplayObject(_inspectableObjects[_currentObjectIndex], _currentObjectIndex==0);
        if (_severalInspectableObjects)
        {
            _nextInspectionObjectButton.gameObject.SetActive(true);
            _nextInspectionObjectButton.onClick.AddListener(DisplayNextObject);
        }
    }
    private void DisplayNextObject()
    {
        _currentObjectIndex++;
        if (_currentObjectIndex < _inspectableObjects.Length)
        {

        }
    }
    //private void InspectObject()
    //{
    //    if (_currentObjectIndex > _inspectableObjects.Length - 1) _currentObjectIndex = 0;

    //    _inspectableObjects[_currentObjectIndex].transform.position = _inspectionTransform.position;
    //    _inspectableObjects[_currentObjectIndex].transform.rotation = _inspectionTransform.rotation;
    //    _currentObjectIndex++;
    //}
    //private void QuitInspection()
    //{
    //    _currentObjectIndex = 0;
    //    if(_nextObjectButton.gameObject.activeSelf) _nextObjectButton.onClick.RemoveListener(InspectObject);
    //    _escapeButton.onClick.RemoveListener(QuitInspection);

    //    _nextObjectButton.gameObject.SetActive(false);
    //    _escapeButton.gameObject.SetActive(false);
    //    //disable objects under inspection (destroy or set false (?))

    //}
}
