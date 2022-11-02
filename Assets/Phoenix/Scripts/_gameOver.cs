using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class _gameOver : MonoBehaviour
{
    //Results
    public TextMeshProUGUI MoneyText;
    public TextMeshProUGUI upgrades;
    Upgradeables uStats;

    private void Start()
    {
        
    }

    void Update()
    {
        MoneyText.text = " " + MoneyManager.Money;
        uStats.UpgradeUsedMost = " ";
    }

    // Sends us back to the Main Menu
    public void QuitGame()
    {
        
        SceneManager.LoadScene(0);

    }

    // Restarts Game, sends it back to Start Level
    public void RestartGame()
    {

        SceneManager.LoadScene(3);
    }
}
