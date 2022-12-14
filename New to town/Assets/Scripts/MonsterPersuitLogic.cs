using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterPersuitLogic : MonoBehaviour
{
    [Header("Persuit")]
    [SerializeField] private int _delay;
    [SerializeField] private NeighborDoorLogic _neighborDoorObj;
    [SerializeField] private RoomDoorBlocker _playerRoomBlocker;
    [SerializeField] private GameObject _safetyPoint;
    private Vector3 _playerCheckPointPosition;
    private Quaternion _playerCheckPointRotation;
    [Header("Timer")]
    [SerializeField] private float _deathTimerValue;
    private bool _chaseActive = false;
    [Header("Monster")]
    [SerializeField] private GameObject _monsterObj;
    [SerializeField] private PlayerMovement _playerMovement;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _playerCheckPointPosition = other.gameObject.transform.position;
            _playerCheckPointRotation = other.gameObject.transform.rotation;
            StartCoroutine(BeginPersuit());
        }
    }
    private IEnumerator BeginPersuit()
    {
        yield return new WaitForSeconds(_delay);
        _chaseActive = true;
        _safetyPoint.SetActive(true);
        _neighborDoorObj.gameObject.SetActive(true);
        _playerRoomBlocker.CanPlayerLeaveRoom(true);
    }
    private void Update()
    {
        if (_chaseActive)
        {
            if (_deathTimerValue > 0)
            {
                _deathTimerValue -= Time.deltaTime;
            }
            else
            {
                StartCoroutine(DieAndReturnToCheckpoint());
            }
        }
    }
    private IEnumerator DieAndReturnToCheckpoint()
    {
        _playerMovement.TogglePlayerMovement(false);
        _playerMovement.TogglePlayerRotaion(false);
        _monsterObj.SetActive(true);
        //TODO: change time to animation's length
        yield return new WaitForSeconds(4);
        _playerMovement.gameObject.transform.position = _playerCheckPointPosition;
        _playerMovement.gameObject.transform.rotation = _playerCheckPointRotation;
    }
}
