using Unity.Mathematics;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // [SerializeField] private float _speed = 5.0f;
    // [SerializeField] private float _rotationSpeed = 120f;
    // [SerializeField] private float _jumpForce = 5.0f;


    // private Rigidbody _rigidbody;

    // private void Start()
    // {
    //     _rigidbody = GetComponent<Rigidbody>();
    // }

    // private void Update()
    // {
    //     if (Input.GetButtonDown("Jump"))
    //     {
    //         _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.VelocityChange);
    //     }
    // }

    // private void FixedUpdate()
    // {
    //     float _moveVertical = Input.GetAxis("Vertical");
    //     Vector3 _movement = transform.forward * _moveVertical * _speed * Time.fixedDeltaTime;
    //                            //Normalde _rigidbody.Position olması gerekiyor.
    //     _rigidbody.MovePosition(transform.position + _movement);

    //     float _moveHorizontal = Input.GetAxis("Horizontal") * _rotationSpeed * Time.fixedDeltaTime;
    //     Quaternion _rotation = Quaternion.Euler(0f, _moveHorizontal, 0f);
    //                             // Normalde _rigidbody.rotation olması gerekiyor.
    //     _rigidbody.MoveRotation(transform.rotation * _rotation);
    // }

    [Header("Movement Speed Settings")]
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _rotationSpeed = 120f;

    [Header("Jump Check Settings")]
    [SerializeField] private bool _canJump;
    [SerializeField] private float _jumpForce = 5f;
    [SerializeField] private float _jumpCooldown;
    [SerializeField] private float _playerHeight;
    [SerializeField] private LayerMask _groundLayer;


    private Rigidbody _rb;


    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Debug.DrawRay(transform.position, Vector3.down * 0.1f, Color.red);
        if (Input.GetButtonDown("Jump") && _canJump && IsGrounded())
        {
            _canJump = false;
            Jump();
            Invoke(nameof(ResetJump), _jumpCooldown);

        }
    }

    private void FixedUpdate()
    {
        float _moveVertical = Input.GetAxis("Vertical");
        Vector3 _movement = transform.forward * _moveVertical * _speed * Time.fixedDeltaTime;
        _rb.MovePosition(_rb.position + _movement);

        float _moveHorizontal = Input.GetAxis("Horizontal") * _rotationSpeed * Time.fixedDeltaTime;
        Quaternion _rotation = Quaternion.Euler(0f, _moveHorizontal, 0f);
        _rb.MoveRotation(_rb.rotation * _rotation);
    }
    private void Jump()
    {
        _rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
    }

    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, _playerHeight * 0.5f + 0.2f, _groundLayer);
    }

    private void ResetJump()
    {
        _canJump = true;
    }

}
