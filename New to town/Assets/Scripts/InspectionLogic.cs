using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InspectionLogic : MonoBehaviour
{
    [SerializeField] private Transform _inspectionTransform;

    [SerializeField] private Button _escapeButton;
    [SerializeField] private Button _nextObjectButton;

    [SerializeField] private GameObject _inspectionAvailableIcon;

    public void InspectionAvailable(bool state)
    {
        _inspectionAvailableIcon.SetActive(state);
    }
    public void DisplayFirstObject(GameObject firstObject)
    {
        
    }
}
