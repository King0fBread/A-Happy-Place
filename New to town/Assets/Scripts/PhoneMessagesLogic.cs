using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneMessagesLogic: MonoBehaviour
{
    [SerializeField] private MessagesButton _replyButton;
    private Conversation _currentConversation;
    [SerializeField] private int _currentReplyIndex = 0;
    public static PhoneMessagesLogic instance { get; private set; }
    private void Awake()
    {
        instance = this;
    }
    [SerializeField] private Conversation[] _conversations;
    [System.Serializable] public class Conversation
    {
        public string conversationName;
        public bool isPlayersTurnToReply;
        public GameObject[] conversationRepliesInOrder;
        public int maxReplyIndex;
    }

    public void FindConversation(string conversationName)
    {
        //finds and cashes the current conversation
        foreach(Conversation convo in _conversations)
        {
            if(conversationName == convo.conversationName)
            {
                _currentConversation = convo;
                CheckConversationStartingStatus();
                break;
            }
        }
    }
    private void CheckConversationStartingStatus()
    {
        //if bot starts conversation = sends first message
        if (!_currentConversation.isPlayersTurnToReply)
        {
            StartCoroutine("SendReply");
        }
    }
    public void TrySendMessage()
    {
        //player used reply button
        if (_currentConversation!=null 
            && _currentConversation.isPlayersTurnToReply 
            && _currentReplyIndex<=_currentConversation.maxReplyIndex)
        {
            _currentConversation.conversationRepliesInOrder[_currentReplyIndex].SetActive(true);
            _currentReplyIndex++;
            _currentConversation.isPlayersTurnToReply = false;
            if (_currentReplyIndex <= _currentConversation.maxReplyIndex) StartCoroutine("SendReply");
        }
    }
    private IEnumerator SendReply()
    {
        yield return new WaitForSeconds(Random.Range(4,8));
        _currentConversation.conversationRepliesInOrder[_currentReplyIndex].SetActive(true);
        _currentConversation.isPlayersTurnToReply = true;
        _currentReplyIndex++;
    }
    public void ClearAllConversations(GameObject[] conversationsArray)
    {
        _currentConversation = null;
        _currentReplyIndex = 0;
        foreach(GameObject reply in conversationsArray)
        {
            reply.SetActive(false);
        }
    }
}
