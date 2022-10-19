using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversationActivator : MonoBehaviour
{
    [SerializeField] private string _conversationNameToActivate;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ActivateConversationByName(_conversationNameToActivate);
            Destroy(gameObject);
        }
    }
    private void ActivateConversationByName(string name)
    {
        PhoneMessagesLogic.instance.TryClearConversation();
        PhoneMessagesLogic.instance.FindConversation(name);
    }
}
