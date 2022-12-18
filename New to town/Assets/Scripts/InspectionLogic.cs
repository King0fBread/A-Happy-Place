using UnityEngine;
using UnityEngine.UI;

public class InspectionLogic : MonoBehaviour
{
    [SerializeField] private Transform _inspectionTransform;

    [SerializeField] private Button _escapeButton;
    [SerializeField] private Button _nextObjectButton;

    [SerializeField] private GameObject _inspectionAvailableIcon;

    [SerializeField] private PlayerMovement _playerMovement;

    public void InspectionAvailable(bool state)
    {
        _inspectionAvailableIcon.SetActive(state);
    }
    public void DisplayObject(GameObject obj, bool isFirstObject = false)
    {
        if (isFirstObject)
        {
            _playerMovement.TogglePlayerMovement(false);
            _playerMovement.TogglePlayerRotaion(false);
            Cursor.lockState = CursorLockMode.None;
        }
        obj.transform.position = _inspectionTransform.position;
        obj.transform.rotation = _inspectionTransform.rotation;

    }
    public void QuitInspection()
    {
        _escapeButton.gameObject.SetActive(false);
        _nextObjectButton.gameObject.SetActive(false);

        _playerMovement.TogglePlayerMovement(true);
        _playerMovement.TogglePlayerRotaion(true);
        Cursor.lockState = CursorLockMode.Locked;
    }
}
