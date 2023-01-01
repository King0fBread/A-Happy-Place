using UnityEngine;

public class NeighborDoorLogic : MonoBehaviour
{
    [SerializeField] private RoomDoorBlocker _neighborDoorBlocker;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _neighborDoorBlocker.CanPlayerLeaveRoom(true);
            SoundsManager.instance.PlaySound(SoundsManager.Sounds.EnvironmentDoorLockUnlocked);
            Destroy(gameObject);
        }
    }
}
