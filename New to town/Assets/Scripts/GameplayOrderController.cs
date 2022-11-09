using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayOrderController : MonoBehaviour
{
    [Header("References to gameplay objects")]
    [SerializeField] private RoomDoorBlocker _playerRoomDoor;
    [SerializeField] private SleepingLogic _playerBed;
    private int _currentDayIndex = 0;

    public void TogglePlayerRoomDoor(bool canUse)
    {
        _playerRoomDoor.CanPlayerLeaveRoom(canUse);
    }
    public void BeginFirstDay()
    {
        //first day initial stuff
        if (_currentDayIndex == 0)
        {
            _currentDayIndex++;
            ActivateConversation("Second");
        }
    }
    public void BeginSecondDay()
    {
        //second day initial stuff
    }
    private void ActivateConversation(string convName)
    {
        PhoneMessagesLogic.instance.TryClearConversation();
        PhoneMessagesLogic.instance.FindConversation(convName);
    }

}
