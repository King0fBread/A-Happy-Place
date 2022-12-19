using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeventhConversationEventsController : MonoBehaviour
{
    [SerializeField] private SleepingLogic _sleepingLogic;
    [SerializeField] private GameObject _windowFace;
    private void OnEnable()
    {
        _sleepingLogic.gameObject.SetActive(true);
        _windowFace.SetActive(true);
    }
}
