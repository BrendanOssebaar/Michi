using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{

    [SerializeField] private InputAction playerInput;
    [SerializeField] private GameObject settingsMenu;
    private bool _isShowing = false;
    private bool _canPress = true;
    private int _timer;

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
        if (playerInput.ReadValue<float>() == 1 && _canPress) 
        {
            settingsMenu.SetActive(!_isShowing);
            _isShowing = !_isShowing;
            _canPress = false;
        }

        _timer++;

        if (_timer == 30)
        {
            _canPress = true;
            _timer = 0;
        }
    }
}
