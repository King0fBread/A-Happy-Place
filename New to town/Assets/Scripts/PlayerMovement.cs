using System.Collections;
using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float _walkingSpeed;
    [SerializeField] private float _runningSpeed;
    [SerializeField] private float _playerSpeed;
    private Rigidbody _thisRb;
    private PlayerInputActions _playerInputActions;
    private Vector2 _inputMovementVector;
    private Vector3 _moveDirection;
    private bool _canMove = true;
    private bool _canRotate = true;
    [Header("Rotation")]
    [SerializeField] private Transform _orientationObjTransform;
    [SerializeField] private Transform _cameraTransform;
    public float rotationSensitivityX;
    public float rotationSetsitivityY;
    private float _rotationX;
    private float _rotationY;
    [Header("References")]
    [SerializeField] private ControllCinemachineShake _controllCinemachineShake;
    [SerializeField] private StaminaLogic _staminaLogic;
    [SerializeField] private ConcreteWalkingSoundTrigger _concreteWalkingSoundTrigger;
    private void Awake()
    {
        _thisRb = GetComponent<Rigidbody>();
        _playerInputActions = new PlayerInputActions();
        _playerInputActions.PlayerMovement.Enable();
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update()
    {
        if (_canMove)
        {
            MovePlayer();
            IsPlayerMoving();
            if (_canRotate) RotatePlayer();
        }
    }
    private void MovePlayer()
    {
        _inputMovementVector = _playerInputActions.PlayerMovement.Movement.ReadValue<Vector2>();
        _moveDirection = _orientationObjTransform.forward * _inputMovementVector.y + _orientationObjTransform.right * _inputMovementVector.x;
        _thisRb.AddForce(_moveDirection.normalized * _playerSpeed * Time.deltaTime, ForceMode.Force);
    }
    private void RotatePlayer()
    {
        float mouseRotationX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * rotationSensitivityX;
        float mouseRotationY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * rotationSetsitivityY;
        _rotationX -= mouseRotationY;
        _rotationY += mouseRotationX;
        _rotationX = Mathf.Clamp(_rotationX, -75f, 65f);
        _orientationObjTransform.rotation = Quaternion.Euler(0f, _rotationY,0f);
        _cameraTransform.rotation = Quaternion.Euler(_rotationX, _rotationY, 0f);
    }
    private void IsPlayerMoving()
    {
        if (_inputMovementVector != Vector2.zero)
        {
            if (Input.GetKey(KeyCode.LeftShift) && _staminaLogic.DoesPlayerHaveStanima()) SetSpeedToRunning();
            else SetSpeedToWalking();
        }
        else
        {
            _controllCinemachineShake.StartShake(_controllCinemachineShake._idleShakeIntensity);

            SoundsManager.instance.StopSound(SoundsManager.Sounds.PlayerFootstepsRunning);
            SoundsManager.instance.StopSound(SoundsManager.Sounds.PlayerFootstepsWalkingConcrete);
            SoundsManager.instance.StopSound(SoundsManager.Sounds.PlayerFootstepsWalkingWood);
        }
    }
    private void SetSpeedToRunning()
    {
        _playerSpeed = _runningSpeed;
        _controllCinemachineShake.StartShake(_controllCinemachineShake._runningShakeIntensity);
        //fix to only play one instance
        SoundsManager.instance.PlaySound(SoundsManager.Sounds.PlayerFootstepsRunning);
        StopCorrectWalkingSound();
    }
    private void SetSpeedToWalking()
    {
        _playerSpeed = _walkingSpeed;
        _controllCinemachineShake.StartShake(_controllCinemachineShake._walkingShakeIntensity);

        SoundsManager.instance.StopSound(SoundsManager.Sounds.PlayerFootstepsRunning);
        PlayCorrectWalkingSound();
    }
    private void PlayCorrectWalkingSound()
    {
        if (_concreteWalkingSoundTrigger.playerIsOnConcrete)
        {
            SoundsManager.instance.StopSound(SoundsManager.Sounds.PlayerFootstepsWalkingWood);
            SoundsManager.instance.PlaySound(SoundsManager.Sounds.PlayerFootstepsWalkingConcrete);
        }
        else
        {
            SoundsManager.instance.StopSound(SoundsManager.Sounds.PlayerFootstepsWalkingConcrete);
            SoundsManager.instance.PlaySound(SoundsManager.Sounds.PlayerFootstepsWalkingWood);
        }
    }
    private void StopCorrectWalkingSound()
    {
        if (_concreteWalkingSoundTrigger.playerIsOnConcrete)
        {
            SoundsManager.instance.StopSound(SoundsManager.Sounds.PlayerFootstepsWalkingConcrete);
        }
        else
        {
            SoundsManager.instance.StopSound(SoundsManager.Sounds.PlayerFootstepsWalkingWood);
        }
    }

    public IEnumerator TempDisableMovement(int secondsOfDisabling)
    {
        _canMove = false;
        yield return new WaitForSeconds(secondsOfDisabling);
        _canMove = true;
    }
    public void TogglePlayerMovement(bool state)
    {
        _canMove = state;
    }
    public void TogglePlayerRotaion(bool state)
    {
        _canRotate = state;
    }

}
