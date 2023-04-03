using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public string SettingMenu;
    public string MainMenu;
    public GameObject pauseMenuUI;
    public Player _Player;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Paused();
            }
        }
    }

    public void Paused()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
        AudioListener.volume = 0f;

    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale =  1f;
        gameIsPaused = false;
        AudioListener.volume = 1f;
    }
    
    public void SettingMenuButton()
    {
        DontDestroyLoadScene.instance.RemoveFromDontDestroyOnLoad();
        Resume();
        SceneManager.LoadScene(SettingMenu);
    }
    
    public void MainMenuButton()
    {
        DontDestroyLoadScene.instance.RemoveFromDontDestroyOnLoad();
        Resume();
        SceneManager.LoadScene(MainMenu);
    }
}
