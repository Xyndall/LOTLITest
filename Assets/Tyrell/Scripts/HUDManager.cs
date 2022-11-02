using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUDManager : MonoBehaviour
{

    //Scripts
    public Upgradeables stats;
    public LevelSystem levelStats;
    public movement playermovement;
    

    //UI Elements
    public TextMeshProUGUI MoneyText;
    public TextMeshProUGUI healthText;

    public Slider dashCoolDown;
    public Slider healthBar;


    //different ui parents
    public GameObject HudParent;
    public GameObject SettingsParent;
    public GameObject SettingPanel;
    public GameObject BasePanel;
    public static bool isPaused = false;


    // Start is called before the first frame update
    public void Start()
    {

        stats = GameObject.FindWithTag("Player").GetComponent<Upgradeables>();
        playermovement = GameObject.FindWithTag("Player").GetComponent<movement>();
        levelStats = GameObject.FindWithTag("Player").GetComponent<LevelSystem>();

        HudParent.SetActive(true);
        SettingsParent.SetActive(false);

        isPaused = false;
    }

    // Update is called once per frame
    public void Update()
    {
        if(stats != null && playermovement != null)
        {
            //Player Stats Text
            //HealthText.text = "Health " + stats.MaxHealth + " / " + stats.Health;
            healthBar.value = stats.sliderHealthVal;
            healthText.text = stats.Health + " / " + stats.MaxHealth;
            MoneyText.text = " " + MoneyManager.Money;

            

            //Dashing Text
            dashCoolDown.value = playermovement._dashCooldown;
        }

        //Settings Stuff
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                //close inventory
                ResumeGame();

            }
            else
            {
                //openInventory
                PauseGame();
                

            }
        }



    }

    public void HudOpenInventory()
    {
        InventoryUIHandler.instance.OpenInventory();
    }
    

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1;
        SettingsParent.SetActive(false);
        HudParent.SetActive(true);
    }

    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0;
        PlayerData.instance.SaveData();
        SettingsParent.SetActive(true);
        HudParent.SetActive(false);
        SettingPanel.SetActive(false);
        BasePanel.SetActive(true);
    }


}
