using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;
    private Rigidbody2D _rigidBody;
    [SerializeField] private InputAction _playerInput;
    private Vector2 _movementDirection;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rigidBody = gameObject.GetComponent<Rigidbody2D>();
    }

    void OnEnable()
    {
        _playerInput.Enable();
    }

    void OnDisable()
    {
        _playerInput.Disable();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _movementDirection = Vector2.zero;
        _movementDirection += _playerInput.ReadValue<Vector2>();
        _rigidBody.linearVelocity = _movementDirection.normalized * _movementSpeed;
    }
}
