using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessagesButton : MonoBehaviour
{
    public void MessageButtonPressed()
    {
        PhoneMessagesLogic.instance.TrySendMessage();
    }
}
