using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
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
    [SerializeField] private float _rotationSensitivityX;
    [SerializeField] private float _rotationSetsitivityY;
    private float _rotationX;
    private float _rotationY;
    [Header("References")]
    [SerializeField] private ControllCinemachineShake _controllCinemachineShake;
    [SerializeField] private StaminaLogic _staminaLogic;
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
            if (_canRotate) RotatePlayer();
            MovePlayer();
            IsPlayerMoving();
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
        float mouseRotationX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * _rotationSensitivityX;
        float mouseRotationY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * _rotationSetsitivityY;
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
        }
    }
    private void SetSpeedToRunning()
    {
        _playerSpeed = _runningSpeed;
        _controllCinemachineShake.StartShake(_controllCinemachineShake._runningShakeIntensity);
    }
    private void SetSpeedToWalking()
    {
        _playerSpeed = _walkingSpeed;
        _controllCinemachineShake.StartShake(_controllCinemachineShake._walkingShakeIntensity);
    }

    //____________For referencing____________
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
