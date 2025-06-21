using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(CharacterController))]
public class FPSMouseLook : MonoBehaviour
{
    // [SerializeField] Camera _playerCamera;
    // [SerializeField] private float _walkSpeed = 6f;
    // [SerializeField] private float _runSpeed = 12f;
    // [SerializeField] private float _jumpPower = 7f;
    // [SerializeField] private float _gravity = 10f;


    // [SerializeField] private float _lookSpeed = 2f;
    // [SerializeField] private float _lookXLimit = 45f;

    // Vector3 _moveDirection = Vector3.zero;
    // private float _rotationX = 0f;

    // [SerializeField] private bool _canMove = true;

    // CharacterController _characterController;


    // private void Start()
    // {
    //     _characterController = GetComponent<CharacterController>();
    //     Cursor.lockState = CursorLockMode.Locked;
    //     Cursor.visible = false;
    // }

    // private void Update()
    // {
    //     #region Handles Movement
    //     Vector3 forward = transform.TransformDirection(Vector3.forward);
    //     Vector3 right = transform.TransformDirection(Vector3.right);

    //     // Press Left Shift to run
    //     bool isRunning = Input.GetKey(KeyCode.LeftShift);
    //     float _curSpeedX = _canMove ? (isRunning ? _runSpeed : _walkSpeed) * Input.GetAxis("Vertical") : 0;
    //     float _curSpeedY = _canMove ? (isRunning ? _runSpeed : _walkSpeed) * Input.GetAxis("Horizontal") : 0;
    //     float movementDirectionY = _moveDirection.y;
    //     _moveDirection = (forward * _curSpeedX) + (right * _curSpeedY);

    //     #endregion

    //     #region Handles Jumping
    //     if (Input.GetButton("Jump") && _canMove && _characterController.isGrounded)
    //     {
    //         _moveDirection.y = _jumpPower;
    //     }
    //     else
    //     {
    //         _moveDirection.y = movementDirectionY;
    //     }
    //     if (!_characterController.isGrounded)
    //     {
    //         _moveDirection.y -= _gravity * Time.deltaTime;
    //     }
    //     #endregion

    //      #region Handles Rotation
    //     _characterController.Move(_moveDirection * Time.deltaTime);

    //     if (_canMove)
    //     {
    //         _rotationX += -Input.GetAxis("Mouse Y") * _lookSpeed;
    //         _rotationX = Mathf.Clamp(_rotationX, -_lookXLimit, _lookXLimit);
    //         _playerCamera.transform.localRotation = Quaternion.Euler(_rotationX, 0, 0);
    //         transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * _lookSpeed, 0);
    //     }

    //     #endregion
    // }

    [SerializeField] private Camera _playerCamera;

    [SerializeField] private float _walkSpeed = 6f;
    [SerializeField] private float _runSpeed = 12f;
    [SerializeField] private float _jumpPower = 5;
    [SerializeField] private float _gravity = 15;

    Vector3 _moveDirection = Vector3.zero;
    private float _rotationX = 0f;

    [SerializeField] private float _lookSpeed = 2f;
    [SerializeField] private float _lookXLimit = 45;

    CharacterController _characterController;
    [SerializeField] bool _canMove;


    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        #region Handles Movement

        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        //Press LShift to run
        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float _curSpeedX = _canMove ? (isRunning ? _runSpeed : _walkSpeed) * Input.GetAxis("Vertical") : 0;
        float _curSpeedY = _canMove ? (isRunning ? _runSpeed : _walkSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = _moveDirection.y;
        _moveDirection = (forward * _curSpeedX) + (right * _curSpeedY);
        #endregion

        #region Handles Jumping
        if (Input.GetButton("Jump") && _canMove && _characterController.isGrounded)
        {
            _moveDirection.y = _jumpPower;
        }
        else
        {
            _moveDirection.y = movementDirectionY;
        }
        if (!_characterController.isGrounded)
        {
            _moveDirection.y -= _gravity * Time.deltaTime;
        }
        #endregion

        #region Handles Turn
        _characterController.Move(_moveDirection * Time.deltaTime);

        if (_canMove)
        {
            _rotationX += -Input.GetAxis("Mouse Y") * _lookSpeed;
            _rotationX = Mathf.Clamp(_rotationX, -_lookXLimit, _lookXLimit);
            _playerCamera.transform.localRotation = Quaternion.Euler(_rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X"), 0);
        }
        #endregion
    }






























}