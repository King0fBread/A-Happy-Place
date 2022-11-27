using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FourthConversationEventsController : MonoBehaviour
{
    [SerializeField] private GameObject _attentionNoteObj;
    [SerializeField] private GameObject _absentNoteCollider;

    [SerializeField] private RoomDoorBlocker _playerRoomBlocker;
    private void OnEnable()
    {
        _attentionNoteObj.SetActive(false);
        _absentNoteCollider.SetActive(true);

        _playerRoomBlocker.CanPlayerLeaveRoom(true);
    }
}
