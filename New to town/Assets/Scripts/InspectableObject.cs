using UnityEngine;
using UnityEngine.UI;

public class InspectableObject : MonoBehaviour
{
    [SerializeField] private GameObject[] _inspectableObjects;
    private FlashlightLogic _flashlightLogic;
    private Vector3[] _defaultObjPositions;
    private Quaternion[] _defaultObjRotations;
    private BoxCollider _thisCollider;
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
        _flashlightLogic = GameObject.FindObjectOfType<FlashlightLogic>();
        _thisCollider = GetComponent<BoxCollider>();

        _severalInspectableObjects = _inspectableObjects.Length > 1;
        CacheObjectsTransforms();
    }
    private void CacheObjectsTransforms()
    {
        _defaultObjPositions = new Vector3[_inspectableObjects.Length];
        _defaultObjRotations = new Quaternion[_inspectableObjects.Length];
        int index = 0;
        foreach(GameObject obj in _inspectableObjects)
        {
            _defaultObjPositions[index] = _inspectableObjects[index].transform.position;
            _defaultObjRotations[index] = _inspectableObjects[index].transform.rotation;
            index++;
        }
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
            _thisCollider.enabled = false;
        }
        _flashlightLogic.TryForceToogleFlashlight(true);
        _flashlightLogic.ToggleFlashlightPermisson(false);
        _escapeButton.gameObject.SetActive(true);
        _escapeButton.onClick.AddListener(QuitInspection);
    }
    private void DisplayNextObject()
    {
        ResetCurrentObjectTransform();

        _currentObjectIndex++;
        if (_currentObjectIndex >= _inspectableObjects.Length)
        {
            _currentObjectIndex = 0;
        }
        _inspectLogic.DisplayObject(_inspectableObjects[_currentObjectIndex]);
    }
    private void ResetCurrentObjectTransform()
    {
        _inspectableObjects[_currentObjectIndex].transform.position = _defaultObjPositions[_currentObjectIndex];
        _inspectableObjects[_currentObjectIndex].transform.rotation = _defaultObjRotations[_currentObjectIndex];
    }
    private void QuitInspection()
    {
        ResetCurrentObjectTransform();
        _currentObjectIndex = 0;
        _thisCollider.enabled = true;
        _inspectLogic.QuitInspection();
        _flashlightLogic.ToggleFlashlightPermisson(true);
    }
}
