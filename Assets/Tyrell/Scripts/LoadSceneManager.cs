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
        Application.Quit();
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

    public void LoadCredits()
    {
        PlayerData.instance.SaveData();
        SceneManager.LoadScene(5);
    }

}
