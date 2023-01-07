using UnityEngine;

public class StudyingDeskLogic : MonoBehaviour
{
    [SerializeField] private Animator _blackScreenAnim;
    [SerializeField] private Transform _studyingTransfrom;
    [SerializeField] private Transform _playerObjectTransform;
    [SerializeField] private Transform _playerCamTransform;
    private PlayerMovement _playerMovement;
    private FlashlightLogic _flashlightLogic;
    private void Awake()
    {
        _playerMovement = _playerObjectTransform.gameObject.GetComponent<PlayerMovement>();
        _flashlightLogic = _playerObjectTransform.gameObject.GetComponent<FlashlightLogic>();
    }
    private void OnMouseDown()
    {
        _blackScreenAnim.gameObject.SetActive(true);
        _blackScreenAnim.SetTrigger("BlackScreen");
        _playerMovement.StartCoroutine("TempDisableMovement", 4);
        _flashlightLogic.TryForceToogleFlashlight(true);
        _flashlightLogic.StartCoroutine("BlockFlashlightUseCoroutine", 4);
        _playerObjectTransform.position = _studyingTransfrom.position;
        _playerCamTransform.rotation = _studyingTransfrom.rotation;

        PhoneMessagesLogic.instance.ActivateConversation("Third");
        SoundsManager.instance.PlaySound(SoundsManager.Sounds.EnvironmentStudying);

        Destroy(gameObject);
    }
}
