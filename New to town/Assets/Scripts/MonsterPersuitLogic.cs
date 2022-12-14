using System.Collections;
using UnityEngine;

public class MonsterPersuitLogic : MonoBehaviour
{
    [Header("Persuit references")]
    [SerializeField] private int _delayInSeconds;
    [SerializeField] private ApartmentSafePoint _safetyPoint;
    [SerializeField] private RoomDoorBlocker _neighborRoomBlocker;
    [SerializeField] private RoomDoorBlocker _playerRoomBlocker;
    [SerializeField] private GameObject _activePersuitText;
    [SerializeField] private GameObject _playerUI;
    [SerializeField] private PlayerMovement _playerMovement;
    private Vector3 _playerCheckPointPosition;
    private Quaternion _playerCheckPointRotation;
    private bool _persuitInProgress = false;
    [Header("Timer")]
    [SerializeField] private float _deathTimerValue;
    private float _defaultDeathTimer;
    private bool _canDoCountdown = false;
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

        yield return new WaitForSeconds(_delayInSeconds);
        _canDoCountdown = true;
        _activePersuitText.SetActive(true);
        _safetyPoint.gameObject.SetActive(true);
        _safetyPoint.AllowPersuitDestruction();
        _neighborRoomBlocker.CanPlayerLeaveRoom(true);
        _playerRoomBlocker.CanPlayerLeaveRoom(true);

        SoundsManager.instance.PlaySound(SoundsManager.Sounds.MonsterOneBreath);
    }
    private void Update()
    {
        if (!_canDoCountdown) return;

        if (_deathTimerValue > 0)
        {
            _deathTimerValue -= Time.deltaTime;
        }
        else 
        {
            _canDoCountdown = false;
            StartCoroutine(DieAndReturnToCheckpoint()); 
        }
    }
    private IEnumerator DieAndReturnToCheckpoint()
    {
        _playerMovement.TogglePlayerMovement(false);
        _playerMovement.TogglePlayerRotaion(false);

        _monsterObj.SetActive(true);
        _playerUI.SetActive(false);
        _activePersuitText.SetActive(false);

        SoundsManager.instance.PlaySound(SoundsManager.Sounds.MonsterGrowl);

        yield return new WaitForSeconds(3.36f);

        _persuitInProgress = false;

        _neighborRoomBlocker.SwitchPlayersPosition();

        _playerMovement.gameObject.transform.position = _playerCheckPointPosition;
        _playerMovement.gameObject.transform.rotation = _playerCheckPointRotation;

        _playerMovement.TogglePlayerMovement(true);
        _playerMovement.TogglePlayerRotaion(true);

        _monsterObj.SetActive(false);
        _playerUI.SetActive(true);

        _deathTimerValue = _defaultDeathTimer;
    }
    private void OnDestroy()
    {
        Destroy(_activePersuitText);
        Destroy(_monsterObj);
    }
}
