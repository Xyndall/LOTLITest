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
    public GameObject GameOver;

    //GameOver Stats
    public TextMeshProUGUI EnemiesKilled;
    public TextMeshProUGUI Upgrades;
    public TextMeshProUGUI HightestDamage;
    public TextMeshProUGUI DamageDealt;


    AudioSource aSource;
    public AudioClip[] aClip;

    // Start is called before the first frame update
    public void Start()
    {
        Time.timeScale = 1;
        aSource = GetComponent<AudioSource>();
        stats = GameObject.FindWithTag("Player").GetComponent<Upgradeables>();
        playermovement = GameObject.FindWithTag("Player").GetComponent<movement>();
        levelStats = GameObject.FindWithTag("Player").GetComponent<LevelSystem>();
        GameOver.SetActive(false);
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

    public void DeathScreen()
    {
        Time.timeScale = 0;
        
        stats.NumberOfUpgrades = stats.ProSpeedUpgraded + stats.ProDamageUpgraded + stats.FireRateUpgraded
            + stats.ProjectilesNumUpgraded + stats.projectileSizeUpgraded + stats.PierceUpgraded + stats.CritChanceUpgraded
            + stats.RicochetUpgraded + stats.ExplosionUpgraded + stats.FreezeUpgraded + stats.SpreadUpgraded;
        EnemiesKilled.text = "Enemies Killed: " + stats.EnemiesKilled;
        DamageDealt.text = "Damage Dealt: " + stats.DamageDealt;
        Upgrades.text = "upgrades used: " + stats.NumberOfUpgrades;
        HightestDamage.text = "Highest Damage: " + stats.HighestDamage;

        GameOver.SetActive(true);
    }



    public void ResumeGame()
    {
        aSource.PlayOneShot(aClip[1]);
        isPaused = false;
        Time.timeScale = 1;
        SettingsParent.SetActive(false);
        HudParent.SetActive(true);
    }

    public void PauseGame()
    {
        aSource.PlayOneShot(aClip[0]);
        isPaused = true;
        Time.timeScale = 0;
        PlayerData.instance.SaveData();
        SettingsParent.SetActive(true);
        HudParent.SetActive(false);
        SettingPanel.SetActive(false);
        BasePanel.SetActive(true);
    }


    public void PlayClick()
    {
        aSource.PlayOneShot(aClip[2]);
    }

}
