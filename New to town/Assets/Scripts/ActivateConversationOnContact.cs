using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateConversationOnContact : MonoBehaviour
{
    [SerializeField] private string _conversationNameToActivate;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PhoneMessagesLogic.instance.ActivateConversation(_conversationNameToActivate);
            gameObject.SetActive(false);
        }
    }
}
