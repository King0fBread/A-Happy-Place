using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterPersuitLogic : MonoBehaviour
{
    [SerializeField] private int _delay;
    [SerializeField] private NeighborDoorLogic _neighborDoorObj;
    [SerializeField] private RoomDoorBlocker _playerRoomBlocker;
    [SerializeField] private GameObject _safetyPoint;
    private Transform _playerCheckPoint;

    [SerializeField] private int _deathTimerValue;
    private bool _chaseActive = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _playerCheckPoint = other.gameObject.transform;
            StartCoroutine(BeginPersuit());
        }
    }
    private IEnumerator BeginPersuit()
    {
        yield return new WaitForSeconds(_delay);
        _safetyPoint.SetActive(true);
        _neighborDoorObj.gameObject.SetActive(true);
        _playerRoomBlocker.CanPlayerLeaveRoom(true);
    }
    private void Update()
    {
        
    }
    public void GetPlayerBackToCheckpoint(PlayerMovement playerObj)
    {
        playerObj.gameObject.transform.position = _playerCheckPoint.position;
        playerObj.gameObject.transform.rotation = _playerCheckPoint.rotation;
    }
}
