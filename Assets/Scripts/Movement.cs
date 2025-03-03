using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    private Rigidbody2D _rigidBody;
    [SerializeField] private InputAction playerInput;
    private Vector2 _movementDirection;
    void Start()
    {
        _rigidBody = gameObject.GetComponent<Rigidbody2D>();
    }

    void OnEnable()
    {
        playerInput.Enable();
    }

    void OnDisable()
    {
        playerInput.Disable();
    }
    void FixedUpdate()
    {
        _movementDirection = Vector2.zero;
        _movementDirection += playerInput.ReadValue<Vector2>();
        _rigidBody.linearVelocity = _movementDirection.normalized * movementSpeed;
    }
}
