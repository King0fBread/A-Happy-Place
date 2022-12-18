using UnityEngine;

public class ActivateConversationOnContact : MonoBehaviour
{
    [SerializeField] private string[] _conversationNamesToActivate;
    private int _convoIndex=0;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (_convoIndex <= _conversationNamesToActivate.Length - 1)
            {
                PhoneMessagesLogic.instance.ActivateConversation(_conversationNamesToActivate[_convoIndex]);
                _convoIndex++;
            }
            gameObject.SetActive(false);
        }
    }
}
