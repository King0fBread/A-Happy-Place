using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeventhConversationEventsController : MonoBehaviour
{
    [SerializeField] private SleepingLogic _sleepingLogic;
    private void OnEnable()
    {
        _sleepingLogic.gameObject.SetActive(true);
    }
}
