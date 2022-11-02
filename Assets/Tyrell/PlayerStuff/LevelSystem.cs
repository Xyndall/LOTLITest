
using TMPro;
using Unity.Collections;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;

public class LevelSystem : MonoBehaviour
{
    #region singleton
    public static LevelSystem instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    #endregion



    public int level;
    public float maxLevel;
    public float currentXp;
    public int nextLevelXp = 100;
    public int EXPpoints;
    public int EXPpointsGiven = 3;
    [Header("Multipliers")]
    [Range(1f, 300f)]
    public float additionMultiplier = 2;
    [Range(2f, 4f)]
    public float powerMultiplier = 2f;
    [Range(7f, 14f)]
    public float divisionMultiplier = 7f;

    public GameObject levelUpEffect;

    [Header("UI")]
    public Image frontXpBar;
    public Image backXpBar;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI XpText;

    //Audio  
    [Header("Audio")]
    //public AudioClip levelUpSound;
    //private AudioSource source;
    //Timers
    private float lerpTimer;
    private float delayTimer;

    void Start()
    {
        


        levelText.text = "Level " + level;
        XpText.text = Mathf.Round(currentXp) + "/" + Mathf.Round(nextLevelXp);
        frontXpBar.fillAmount = currentXp / nextLevelXp;
        backXpBar.fillAmount = currentXp / nextLevelXp;
        nextLevelXp = CalculateNextLevelXp();
        //source = GetComponent<AudioSource>();
    }

    void Update()
    {
        UpdateXpUI();
        if (level != maxLevel)
        {
            if (currentXp >= nextLevelXp)
            {
                LevelUp();
            }        
        }
        else
        {
            currentXp = nextLevelXp;
            XpText.text = "MAX";
            frontXpBar.fillAmount = currentXp / nextLevelXp;
            backXpBar.fillAmount = currentXp / nextLevelXp;
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            GainExperienceScalable(25, 1);
        }
    }
    private void UpdateXpUI() 
    {
        float xpFraction = currentXp / nextLevelXp;
        float fXP = frontXpBar.fillAmount;

        if (fXP < xpFraction)
        {
            delayTimer += Time.deltaTime;
            backXpBar.fillAmount = xpFraction;
            if (delayTimer > 3)
            {
                lerpTimer += Time.deltaTime;
                float percentComplete = lerpTimer / 5;
                percentComplete = percentComplete * percentComplete;
                frontXpBar.fillAmount = Mathf.Lerp(fXP, backXpBar.fillAmount, percentComplete);
            }

        }
        XpText.text = currentXp + "/" + nextLevelXp;
    }

    public void GainExperienceFlatRate(float xpGained)
    {
            currentXp += xpGained;
            lerpTimer = 0f;
            delayTimer = 0f;
    }
    public void GainExperienceScalable(float xpGained, int passedLevel)
    {
        if (passedLevel < level)
        {
            float multiplier = 1 + (level - passedLevel) * 0.1f;
            currentXp += Mathf.Round(xpGained*multiplier);

        }
        else
        {
            currentXp += xpGained;

        }

        lerpTimer = 0f;
        delayTimer = 0f;

    }

    public void LevelUp() 
    {
        level += 1;
        backXpBar.fillAmount = 0f;
        frontXpBar.fillAmount = 0f;
        currentXp = Mathf.Round(currentXp-nextLevelXp);

        nextLevelXp = CalculateNextLevelXp();
        level = Mathf.Clamp(level,0, 50);

        XpText.text = Mathf.Round(currentXp) + "/" + nextLevelXp;
        levelText.text = "Level " + level;
        EXPpoints += EXPpointsGiven;
        GameObject effect = Instantiate(levelUpEffect, transform.position, Quaternion.identity);
        Destroy(effect, 2);
        //source.PlayOneShot(levelUpSound);
    }

    private int CalculateNextLevelXp() 
    {
        int solveForRequiredXp = 500;
        for (int levelCycle = 1; levelCycle <= level; levelCycle++)
        {
            solveForRequiredXp += (int)Mathf.Floor(levelCycle + additionMultiplier * Mathf.Pow(powerMultiplier, levelCycle / divisionMultiplier));
        }
        return solveForRequiredXp / 4;
    }
}
