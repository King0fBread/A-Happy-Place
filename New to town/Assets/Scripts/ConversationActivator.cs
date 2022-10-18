using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversationActivator : MonoBehaviour
{
    private void Start()
    {
        PhoneMessagesLogic.instance.FindConversation("First");
    }
    public void ActivateConversationByName(string name)
    {
        PhoneMessagesLogic.instance.FindConversation(name);
    }
}
