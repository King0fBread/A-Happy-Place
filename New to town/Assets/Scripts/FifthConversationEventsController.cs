using UnityEngine;

public class FifthConversationEventsController : MonoBehaviour
{
    [SerializeField] private GameObject _proximityToTVRoomObj;

    [SerializeField] private RoomDoorBlocker _playerRoomBlocker;
    private void OnEnable()
    {
        _proximityToTVRoomObj.SetActive(true);

        _playerRoomBlocker.CanPlayerLeaveRoom(true);
    }
}
