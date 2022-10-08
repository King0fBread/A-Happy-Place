using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float _moveSpeed;
    private Rigidbody _thisRb;
    private PlayerInputActions _playerInputActions;
    private Vector2 _inputMovementVector;
    private Vector3 _moveDirection;
    [Header("Rotation")]
    [SerializeField] private Transform _orientationObjTransform;
    [SerializeField] private Transform _cameraTransform;
    [SerializeField] private float _rotationSensitivityX;
    [SerializeField] private float _rotationSetsitivityY;
    private float _rotationX;
    private float _rotationY;
    private void Awake()
    {
        _thisRb = GetComponent<Rigidbody>();
        _playerInputActions = new PlayerInputActions();
        _playerInputActions.PlayerMovement.Enable();
    }
    private void Update()
    {
        MovePlayer();
        RotatePlayer();
    }
    private void MovePlayer()
    {
        _inputMovementVector = _playerInputActions.PlayerMovement.Movement.ReadValue<Vector2>();
        _moveDirection = _orientationObjTransform.forward * _inputMovementVector.y + _orientationObjTransform.right * _inputMovementVector.x;
        _thisRb.AddForce(_moveDirection.normalized * _moveSpeed, ForceMode.Force);
    }
    private void RotatePlayer()
    {
        float mouseRotationX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * _rotationSensitivityX;
        float mouseRotationY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * _rotationSetsitivityY;
        _rotationX -= mouseRotationY;
        _rotationY += mouseRotationX;
        _rotationX = Mathf.Clamp(_rotationX, -90f, 90f);
        _orientationObjTransform.rotation = Quaternion.Euler(0f, _rotationY,0f);
        _cameraTransform.rotation = Quaternion.Euler(_rotationX, _rotationY, 0f);

    }
    

}
