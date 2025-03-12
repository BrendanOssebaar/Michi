using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{

    [SerializeField] private InputAction playerInput;
    private GameObject _currentMenu;
    public bool isShowing = false;
    public bool canPress = true;
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
        if (playerInput.ReadValue<float>() == 1 && canPress) 
        {
            if (!isShowing)
            {
                OpenMenu(settingsMenu);
            }
            else
            {
                CloseMenu(_currentMenu);
            }
        }

        _timer++;

        if (_timer >= 45)
        {
            canPress = true;
            _timer = 0;
        }
    }

    public void OpenMenu(GameObject menu)
    {
        if (_currentMenu)
        {
            CloseMenu(_currentMenu);
        }
        menu.SetActive(true);
        isShowing = true;
        canPress = false;
        _currentMenu = menu;
    }

    public void CloseMenu(GameObject menu)
    {
        _currentMenu.SetActive(false);
        isShowing = false;
        canPress = false;
        _currentMenu = settingsMenu;
    }
}
