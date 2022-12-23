using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EightsConversationEventsController : MonoBehaviour
{
    [SerializeField] private RoomDoorBlocker _playerDoorBlocker;
    [SerializeField] private RoomDoorBlocker _fireRoomDoorBlocker;
    [SerializeField] private PlayerRoomPeephole _peepholeLogic;
    private void OnEnable()
    {
        _peepholeLogic.EnablePeeping();
        _playerDoorBlocker.CanPlayerLeaveRoom(true);
        _fireRoomDoorBlocker.CanPlayerLeaveRoom(true);
    }
}
