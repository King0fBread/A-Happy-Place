using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepingAction : MonoBehaviour
{
    [SerializeField] private Animator _blackScreenAnim;
    [SerializeField] private GameObject _playerObj;
    [SerializeField] private GameObject _playerCameraObj;
    [SerializeField] private Transform _sleepTransform;
    private PlayerMovement _playerMovement;
    private bool _canSleep = true;
    private void Start()
    {
        GameplayEvents.current.onSleepAttempted += OnSleepInitiated;
        _playerMovement = _playerObj.GetComponent<PlayerMovement>();
    }
    private void OnMouseDown()
    {
        GameplayEvents.current.SleepTriggered();
    }
    private void OnSleepInitiated()
    {
        if (_canSleep)
        {
            _blackScreenAnim.SetTrigger("Sleep");
            _playerObj.transform.position = _sleepTransform.position;
            _playerCameraObj.transform.rotation = _sleepTransform.rotation;
            _playerMovement.StartCoroutine("TempDisableMovement", 4);
        }
        else
        {
            Debug.Log("not sleepy yet");
        }
        //disable _canSleep in the end
    }
    public void CanPlayerSleep(bool value)
    {
        _canSleep = value;
    }
}
