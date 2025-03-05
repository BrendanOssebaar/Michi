using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{

    [SerializeField] private InputAction playerInput;
    public GameObject currentMenu;
    private bool _isShowing = false;
    private bool _canPress = true;
    private int _timer;
    [SerializeField] private GameObject settingsMenu;
    
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
            if (!_isShowing)
            {
                OpenMenu();
            }
            else
            {
                CloseMenu();
            }
        }

        _timer++;

        if (_timer == 30)
        {
            _canPress = true;
            _timer = 0;
        }
    }

    public void OpenMenu()
    {
        currentMenu.SetActive(true);
        _isShowing = true;
        _canPress = false;
    }

    public void CloseMenu()
    {
        currentMenu.SetActive(false);
        _isShowing = false;
        _canPress = false;
        currentMenu = settingsMenu;
    }
}
