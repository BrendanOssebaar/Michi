using System.Dynamic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interactor : MonoBehaviour
{
    private bool _canInteract;
    private GameObject _other;
    [SerializeField] private InputAction playerInput;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void OnEnable()
    {
        playerInput.Enable();
    }

    void OnDisable()
    {
        playerInput.Disable();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (playerInput.ReadValue<float>() == 1 && _canInteract)
        {
            _canInteract = false;
            _other.gameObject.GetComponent<Interactable>().OpenMenu();
        }
        if (_other)
        {
            if (_other.gameObject.GetComponent<Interactable>())
            {
                if (_other.gameObject.GetComponent<Interactable>().menu.activeSelf == false)
                {
                    _canInteract = true;
                }
            }
            
        }
    }

    void OnTriggerEnter2D(Collider2D Other)
    {
        _other = Other.gameObject;
        if (_other.gameObject.GetComponent<Interactable>())
        {
            _canInteract = true;
        } 
    }

    void OnTriggerExit2D(Collider2D Other)
    {
        if(Other.gameObject == _other)
        {
            _canInteract = false;
            _other = null;
        }
    }
}
