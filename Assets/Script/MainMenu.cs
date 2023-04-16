using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    
    public TMP_Dropdown Dresolution;
    public Toggle Fullscreen;
    
    public void PlayGame()
    {
        SceneManager.LoadScene("IntroCinematic");
    }

    public void Options()
    {
        SceneManager.LoadScene("Settings Menu");

    }

    public void Back()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void SetResolution()
    {
        switch (Dresolution .value)
        {
            case 0:
                Screen.SetResolution(640,360,isFS());
                break;
            case 1:
                Screen.SetResolution(1280,720,isFS());
                break;
            case 2:
                Screen.SetResolution(1920, 1080, isFS());
                break;
        }
    }

    public bool isFS()
    {
        if (Fullscreen.isOn)
        {
            Screen.fullScreen = true;
            return true;
        }
        else
        {
            Screen.fullScreen = false;
            return true;
        }
    }

    public void Soundvolume()
    {
        
    }
}
