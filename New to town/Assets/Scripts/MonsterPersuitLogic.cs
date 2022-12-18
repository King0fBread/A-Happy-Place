using System.Collections;
using UnityEngine;

public class MonsterPersuitLogic : MonoBehaviour
{
    [Header("Persuit")]
    [SerializeField] private int _delay;
    [SerializeField] private ApartmentSafePoint _safetyPoint;
    [SerializeField] private RoomDoorBlocker _neighborRoomBlocker;
    [SerializeField] private RoomDoorBlocker _playerRoomBlocker;
    [SerializeField] private GameObject _UI;
    [SerializeField] private PlayerMovement _playerMovement;
    private Vector3 _playerCheckPointPosition;
    private Quaternion _playerCheckPointRotation;
    private bool _persuitInProgress = false;
    [Header("Timer")]
    [SerializeField] private float _deathTimerValue;
    private float _defaultDeathTimer;
    private bool _canStartCountdown = false;
    [Header("Monster")]
    [SerializeField] private GameObject _monsterObj;
    private void Awake()
    {
        _defaultDeathTimer = _deathTimerValue;  
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !_persuitInProgress)
        {
            _playerCheckPointPosition = other.gameObject.transform.position;
            _playerCheckPointRotation = other.gameObject.transform.rotation;
            StartCoroutine(BeginPersuit());
        }
    }
    private IEnumerator BeginPersuit()
    {
        _persuitInProgress = true;

        yield return new WaitForSeconds(_delay);
        _canStartCountdown = true;
        _safetyPoint.gameObject.SetActive(true);
        _safetyPoint.AllowPersuitDestruction();
        _neighborRoomBlocker.CanPlayerLeaveRoom(true);
        _playerRoomBlocker.CanPlayerLeaveRoom(true);
    }
    private void Update()
    {
        if (!_canStartCountdown) return;

        if (_deathTimerValue > 0) _deathTimerValue -= Time.deltaTime;
        else StartCoroutine(DieAndReturnToCheckpoint());
    }
    private IEnumerator DieAndReturnToCheckpoint()
    {
        _playerMovement.TogglePlayerMovement(false);
        _playerMovement.TogglePlayerRotaion(false);

        _monsterObj.SetActive(true);
        _UI.SetActive(false);

        yield return new WaitForSeconds(3.36f);

        _persuitInProgress = false;

        _playerMovement.gameObject.transform.position = _playerCheckPointPosition;
        _playerMovement.gameObject.transform.rotation = _playerCheckPointRotation;

        _playerMovement.TogglePlayerMovement(true);
        _playerMovement.TogglePlayerRotaion(true);

        _monsterObj.SetActive(false);
        _UI.SetActive(true);

        _deathTimerValue = _defaultDeathTimer;
    }
}
