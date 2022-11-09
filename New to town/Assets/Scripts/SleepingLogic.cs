using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepingLogic : MonoBehaviour
{
    [SerializeField] private Animator _blackScreenAnim;
    [SerializeField] private GameObject _playerObj;
    [SerializeField] private GameObject _playerCameraObj;
    [SerializeField] private Transform _sleepTransform;
    private GameplayOrderController _gameplayController;
    private PlayerMovement _playerMovement;
    private int _sleepSessionIndex = 0;
    private bool _canSleep = false;
    private void Awake()
    {
        _gameplayController = GameObject.FindGameObjectWithTag("GameOrderManager").
            GetComponent<GameplayOrderController>();
        _playerMovement = _playerObj.GetComponent<PlayerMovement>();
    }
    private void OnMouseDown()
    {
        OnSleepInitiated();
    }
    private void OnSleepInitiated()
    {
        if (CheckIfCanSleep())
        {
            _sleepSessionIndex++;
            CheckSleepSessionIndex();

            _blackScreenAnim.gameObject.SetActive(true);
            _blackScreenAnim.SetTrigger("Sleep");
            _playerObj.transform.position = _sleepTransform.position;
            _playerCameraObj.transform.rotation = _sleepTransform.rotation;
            _playerMovement.StartCoroutine("TempDisableMovement", 4);
        }
        else
        {
            Debug.Log("not sleepy yet");
        }
    }
    private void CheckSleepSessionIndex()
    {
        if (_sleepSessionIndex == 1) _gameplayController.BeginFirstDay();
        if (_sleepSessionIndex == 2) _gameplayController.BeginSecondDay();
    }
    public bool CheckIfCanSleep()
    {
        _canSleep = PhoneMessagesLogic.instance.ConversationIsFinished();
        //potentially more checks
        return _canSleep;
    }
}
