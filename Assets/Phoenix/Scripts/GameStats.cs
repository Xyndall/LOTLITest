using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameStats : MonoBehaviour
{

    //Game Stats
    public TextMeshProUGUI killStats;
    public TextMeshProUGUI longestRunStats;
    public TextMeshProUGUI LifeStats;
    public TextMeshProUGUI DeathStats;
    public TextMeshProUGUI upgradesCollected;
    public TextMeshProUGUI moneyCollected;
    public TextMeshProUGUI damageDealtStats;
    public TextMeshProUGUI damageTakenStats;
    
    //UI Parents
    public GameObject textparents;
    public GameObject BG;
    public GameObject Title;

    public static bool isPaused = false;

    private void Start()
    {
        textparents.SetActive(true);
        BG.SetActive(true);
        Title.SetActive(true);

        isPaused = false;
    }

    // Update is called once per frame
    public void Update()
    {

        //press button/key opens game stats overall
        if (Input.GetKeyDown(KeyCode.U))
        {
            //close Stats
            OpenStats();
        }
        else
        {
            CloseStats();
        }
    }

    //Open Stats for the Player
    public void OpenStats()
    {
        isPaused = false;
        Time.timeScale = 1;
        textparents.SetActive(true);
        BG.SetActive(true);
        Title.SetActive(true);
    }

    //Closes the stat windows
    public void CloseStats()
    {
        isPaused = false;
        Time.timeScale = 0;
        textparents.SetActive(false);
        BG.SetActive(false);
        Title.SetActive(false);
    }
}
