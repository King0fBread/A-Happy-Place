using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonRemoveListenersOnDisable : MonoBehaviour
{
    private Button _thisButton;
    private void Awake()
    {
        _thisButton = GetComponent<Button>();
    }
    private void OnDisable()
    {
        _thisButton.onClick.RemoveAllListeners();
    }
}
