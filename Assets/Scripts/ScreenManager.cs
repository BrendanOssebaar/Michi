using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScreenManager : MonoBehaviour
{

    private Toggle _toggle;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        WaitForScreenChange(1920, 1080, true);
    }

    // switches resolutions based on the selected options.
    public void ChangeScreenSize(TMPro.TMP_Dropdown dropdown)
    {
        switch(dropdown.value)
        {
            case 0:
                WaitForScreenChange(1920, 1080, true);
                break;
            case 1:
                WaitForScreenChange(3840, 2160, true);
                break;
            case 2:
                WaitForScreenChange(1440, 900, true);
                break;
        }
    }

    // this happens one frame after we toggle the resolution which gives unity enough time to apply it, doesnt work otherwise because of the time.
    public void WaitForScreenChange(int Width, int Height, bool Fullscreen)
    {
        Height = Screen.height;
        Width = Screen.width;

        Screen.SetResolution(Width, Height, Fullscreen);
    }

    //turns the opposite toggle off and toggles if were in fullscreen mode.
    public void ToggleFullScreen(bool Fullscreen) 
    {
        if (Fullscreen)
        {
            Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
            _toggle.SetIsOnWithoutNotify(false);
        }
        else
        {
            Screen.fullScreenMode = FullScreenMode.Windowed;
            _toggle.SetIsOnWithoutNotify(false);
        }
    }


    //sets the toggles refrence.
    public void SetToggleRefrence(Toggle toggle)
    {
        _toggle = toggle;
    }

}