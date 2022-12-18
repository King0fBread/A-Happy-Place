using System.Collections;
using UnityEngine;

public class PhoneMessagesLogic: MonoBehaviour
{
    [Header("UI objects to toggle")]
    [SerializeField] private GameObject _unreadMessagesIcon;
    [SerializeField] private GameObject _chatroomObject;
    [Header("Messages Logic")]
    [SerializeField] private int _currentReplyIndex = 0;
    private Conversation _currentConversation;
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
        public GameObject storylineScriptToTrigger = null;
        [HideInInspector] public int maxReplyIndex;
    }

    private void FindConversation(string conversationName)
    {
        //finds and cashes the current conversation
        foreach(Conversation convo in _conversations)
        {
            if(conversationName == convo.conversationName)
            {
                _chatroomObject.SetActive(false);
                _unreadMessagesIcon.SetActive(true);

                _currentConversation = convo;
                _currentConversation.maxReplyIndex = _currentConversation.conversationRepliesInOrder.Length - 1;
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
    private IEnumerator SendReply()
    {
        yield return new WaitForSeconds(Random.Range(4,8));
        _currentConversation.conversationRepliesInOrder[_currentReplyIndex].SetActive(true);
        _currentConversation.isPlayersTurnToReply = true;
        _currentReplyIndex++;

        //checking if the convo is over from bot's side, if true - enabling a script object
        if (ConversationIsFinished() && _currentConversation.storylineScriptToTrigger != null)
            _currentConversation.storylineScriptToTrigger.SetActive(true);
    }
    private void TryClearConversation()
    {
        if(_currentConversation != null && _currentReplyIndex >= _currentConversation.maxReplyIndex)
        {
            foreach(GameObject reply in _currentConversation.conversationRepliesInOrder)
            {
                reply.SetActive(false);
            }
            _currentConversation = null;
            _currentReplyIndex = 0;
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
            else
            {
                //checking if the convo is over from the player's side, if true - enabling a script object
                if (ConversationIsFinished() && _currentConversation.storylineScriptToTrigger!=null) 
                    _currentConversation.storylineScriptToTrigger.SetActive(true);
            }
        }
    }
    public bool ConversationIsFinished()
    {
        return _currentReplyIndex >= _currentConversation.maxReplyIndex;
    }
    public void ActivateConversation(string conversationName)
    {
        TryClearConversation();
        FindConversation(conversationName);
    }
}
