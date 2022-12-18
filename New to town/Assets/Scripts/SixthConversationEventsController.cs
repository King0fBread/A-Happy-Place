using UnityEngine;

public class SixthConversationEventsController : MonoBehaviour
{
    [SerializeField] private PlayerRoomPeephole _roomPeepHole;

    private void OnEnable()
    {
        _roomPeepHole.SetMonsterOutside();
    }
}
