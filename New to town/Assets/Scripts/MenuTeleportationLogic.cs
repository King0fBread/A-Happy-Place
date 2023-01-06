using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuTeleportationLogic : MonoBehaviour
{
    [SerializeField] private GameObject _cameraObj;
    [SerializeField] private GameObject _cameraResetButton;
    [SerializeField] private Transform _newCameraLocation;

    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _selectionSound;

    private MenuCameraDefaultPositionLogic _cameraResetLogic;
    private string _thisTag;
    private void Awake()
    {
        _cameraResetLogic = _cameraObj.GetComponent<MenuCameraDefaultPositionLogic>();
        _thisTag = gameObject.tag;
    }
    private void OnMouseDown()
    {
        if (_cameraResetLogic.cameraIsNotFocused)
        {
            _cameraResetButton.SetActive(true);

            _cameraObj.transform.position = _newCameraLocation.position;
            _cameraObj.transform.rotation = _newCameraLocation.rotation;
            _cameraResetLogic.cameraIsNotFocused = false;
        }
        else
        {
            _audioSource.PlayOneShot(_selectionSound);
            CheckTagAndPerformSpecificAction();
        }
    }
    private void CheckTagAndPerformSpecificAction()
    {
        switch (_thisTag)
        {
            case "MenuExit":
                Application.Quit();
                break;

            case "MenuDoor":
                //async scene load
                SceneLoader.LoadScene(SceneLoader.Scenes.GameScene);
                break;
            case "MenuPaper":
                break;
                
        }
    }
}
