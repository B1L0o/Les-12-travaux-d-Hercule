using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string startLevel;
    public string settingMenu;
    public void StartGame()
    {
        SceneManager.LoadScene(startLevel);
    }

    public void SettingsButton()
    {
        SceneManager.LoadScene(settingMenu);
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }
}
