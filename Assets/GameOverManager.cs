
using System;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverUI;
    public static GameOverManager instance;

    private void Awake()
    {
        if (instance!=null)
        {
            Debug.LogWarning("Il y a plus d'une instance de GameOverManager !!!!");
            return;
        }
    }

    public void WhenPlayerDeath()
    {
        gameOverUI.SetActive(true);
    }
}
