using UnityEngine;

public class NeighborDoorLogic : MonoBehaviour
{
    [SerializeField] private RoomDoorBlocker _neighborDoorBlocker;
    //audio
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //opening sound
            _neighborDoorBlocker.CanPlayerLeaveRoom(true);
            Destroy(gameObject);
        }
    }
}
