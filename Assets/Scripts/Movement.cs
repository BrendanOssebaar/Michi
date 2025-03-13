using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    private Rigidbody2D _rigidBody;
    [SerializeField] private InputAction playerInput;
    private Vector2 _movementDirection;
    private SpriteRenderer _spriteRenderer;
    [SerializeField] private List<Sprite> _sprites;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rigidBody = gameObject.GetComponent<Rigidbody2D>();
        _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
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
        if(playerInput.ReadValue<Vector2>().normalized == new Vector2(0, 1))
        {
            _spriteRenderer.sprite = _sprites[2];
        }
        if (playerInput.ReadValue<Vector2>().normalized == new Vector2(1, 0))
        {
            _spriteRenderer.sprite = _sprites[3];
        }
        if (playerInput.ReadValue<Vector2>().normalized == new Vector2(0, -1))
        {
            _spriteRenderer.sprite = _sprites[0];
        }
        if (playerInput.ReadValue<Vector2>().normalized == new Vector2(-1, 0))
        {
            _spriteRenderer.sprite = _sprites[1];
        }

        _rigidBody.linearVelocity = _movementDirection.normalized * movementSpeed;
    }
}
