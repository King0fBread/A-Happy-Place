using UnityEngine;

public class SleepingLogic : MonoBehaviour
{
    [SerializeField] private Animator _blackScreenAnim;
    [SerializeField] private GameObject _playerObj;
    [SerializeField] private GameObject _playerCameraObj;
    [SerializeField] private Transform _sleepTransform;
    private PlayerMovement _playerMovement;
    private int _sleepSessionIndex = 0;
    private void Awake()
    {
        _playerMovement = _playerObj.GetComponent<PlayerMovement>();
        gameObject.SetActive(false);
    }
    private void OnMouseDown()
    {
        OnSleepInitiated();
    }
    private void OnSleepInitiated()
    {
        _sleepSessionIndex++;
        CheckSleepSessionIndex();

        _blackScreenAnim.gameObject.SetActive(true);
        _blackScreenAnim.SetTrigger("BlackScreen");
        _playerObj.transform.position = _sleepTransform.position;
        _playerCameraObj.transform.rotation = _sleepTransform.rotation;
        _playerMovement.StartCoroutine("TempDisableMovement", 4);
        gameObject.SetActive(false);
    }
    private void CheckSleepSessionIndex()
    {
        if (_sleepSessionIndex == 1) PhoneMessagesLogic.instance.ActivateConversation("Second");
        //if (_sleepSessionIndex == 2) PhoneMessagesLogic.instance.ActivateConversation("something");
    }
}
