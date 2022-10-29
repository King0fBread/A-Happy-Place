using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepingAction : MonoBehaviour
{
    [SerializeField] private bool _canSleep = false;
    private void Start()
    {
        GameplayEvents.current.onSleepAttempted += OnSleepInitiated;
    }
    private void OnMouseDown()
    {
        GameplayEvents.current.SleepTriggered();
    }
    private void OnSleepInitiated()
    {
        if (_canSleep)
        {
            Debug.Log("sleep logic");
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
