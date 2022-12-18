using UnityEngine;

public class MessagesButton : MonoBehaviour
{
    public void MessageButtonPressed()
    {
        PhoneMessagesLogic.instance.TrySendMessage();
    }
}
