using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class VictoryManager : MonoBehaviour
{
    public string MainMenu;
    public GameObject victoryUI;
    public static VictoryManager instance;

    private void Awake()
    {
        if (instance!=null)
        {
            Debug.LogWarning("Il y a plus d'une instance de VictoryManager !!!!");
            return;
        }

        instance = this;
    }

    public void WhenBossDeath()
    {
        if (CurrentSceneManager.instance.isPlayerPresentByDefault)
        {
            DontDestroyLoadScene.instance.RemoveFromDontDestroyOnLoad();
        }
        victoryUI.SetActive(true);
    }
    
    public void MainMenuButton()
    {
        SceneManager.LoadScene(MainMenu);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
