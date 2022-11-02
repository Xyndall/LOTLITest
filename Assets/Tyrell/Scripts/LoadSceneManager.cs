using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneManager : MonoBehaviour
{
    #region singleton
    public static LoadSceneManager instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    #endregion


    public void QuitGame()
    {
        PlayerData.instance.SaveData();

        Application.Quit();
    }

    // Restarts Game, sends it back to Start Level
    public void RestartGame()
    {
        PlayerData.instance.SaveData();
        SceneManager.LoadScene(1);
    }

    public void LoadMenu()
    {
        PlayerData.instance.SaveData();
        SceneManager.LoadScene(0);
    }

    public void LoadGameOver()
    {
        SceneManager.LoadScene(2);
    }

    public void LoadWaveGame()
    {
        PlayerData.instance.SaveData();
        SceneManager.LoadScene(1);
    }

    public void LoadRogueGame()
    {
        PlayerData.instance.SaveData();
        SceneManager.LoadScene(2);
    }

    public void LoadStartingArea()
    {
        PlayerData.instance.SaveData();
        SceneManager.LoadScene(3);
    }

    public void LoadTutorial()
    {
        PlayerData.instance.SaveData();
        SceneManager.LoadScene(4);
    }
}
