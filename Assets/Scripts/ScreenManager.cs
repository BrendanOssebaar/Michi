using System;
using UnityEngine;
using System.Collections;

public class ScreenManager : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        WaitForScreenChange(1920, 1080, true);
    }

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

    public void WaitForScreenChange(int Width, int Height, bool Fullscreen)
    {
        Height = Screen.height;
        Width = Screen.width;

        Screen.SetResolution(Width, Height, Fullscreen);
    }

    public void ToggleFullScreen(bool Fullscreen) 
    {
        if (Fullscreen)
        {
            Screen.FullScreen = Fullscreen;
        }
    }

}