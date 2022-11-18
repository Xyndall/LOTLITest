using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerData : MonoBehaviour
{
    #region singleton
    public static PlayerData instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    #endregion


    //Scripts
    public LevelSystem _levelSystem;
    public Upgradeables _upgradeables;

    //Saved variables
    //levels
    public int _Level;
    int DefaultLevel = 1;
    public float _currentXP;
    float DefaultCurrentXp = 0;
    public int _nextLevelXp;
    int DefaultNextLevelXp = 0;
    public int _xpPoints;
    int DefaultXpPoints = 0;

    //upgrades
    int DefaultUpgradeLevel = 0;

    #region Items
    public Item explosion;
    public int _explosionLevel;


    public Item Damage;
    public int _damageLevel;

    public Item fireRate;
    public int _fireRateLevel;

    public Item Ricochet;
    public int _ricochetLevel;

    public Item SpeedUp;
    public int _speedLevel;

    public Item Duplicate;
    public int _duplicateLevel;

    public Item Crit;
    public int _critLevel;

    public Item Spread;
    public int _spreadLevel;

    public Item Freeze;
    public int _freezeLevel;

    public Item Big;
    public int _bigLevel;

    public Item Pierce;
    public int _pierceLevel; 
    #endregion

    public static bool TutorialCompleted = false;
    bool tutorialDefault = false;

    public static bool EnhancementInfoClosed = false;
    bool InfoDefault = false;

    //settings
    float DefaulAudioValue = 0.5f;
    bool DefaultBoolValue = true;
    
    int DefaultResValue;
    int DefaultQualtityValue = 6;
    [HideInInspector] public int ResoulutionSet;
    [HideInInspector]  public int QualitySet;
    [HideInInspector]  public bool FullscreenSet;


    public void Start()
    {
        Resolution[] res = Screen.resolutions;
        DefaultResValue = Mathf.Max(res.Length);

        LoadData();
        
        Resolution Res = Screen.resolutions[ResoulutionSet - 1];
        
        Screen.SetResolution(Res.width, Res.height, Screen.fullScreen);
        

        QualitySettings.SetQualityLevel(QualitySet);
        
        Screen.fullScreenMode = FullscreenSet ? FullScreenMode.ExclusiveFullScreen : FullScreenMode.Windowed;

        _levelSystem.level = _Level;
        _levelSystem.currentXp = _currentXP;
        _levelSystem.nextLevelXp = _nextLevelXp;
        _levelSystem.EXPpoints = _xpPoints;

        #region Upgrade
        //Upgrades

        explosion.level = _explosionLevel;
        explosion.UpgradeAmount = 0;
        explosion.baselevel = 0;
        explosion.UpdateUpgrade();

        Damage.level = _damageLevel;
        Damage.UpgradeAmount = 0;
        Damage.baselevel = 0;
        Damage.UpdateUpgrade();

        fireRate.level = _fireRateLevel;
        fireRate.UpgradeAmount = 0;
        fireRate.baselevel = 0;
        fireRate.UpdateUpgrade();

        Ricochet.level = _ricochetLevel;
        Ricochet.UpgradeAmount = 0;
        Ricochet.baselevel = 0;
        Ricochet.UpdateUpgrade();

        SpeedUp.level = _speedLevel;
        SpeedUp.UpgradeAmount = 0;
        SpeedUp.baselevel = 0;
        SpeedUp.UpdateUpgrade();

        Duplicate.level = _duplicateLevel;
        Duplicate.UpgradeAmount = 0;
        Duplicate.baselevel = 0;
        Duplicate.UpdateUpgrade();

        Crit.level = _critLevel;
        Crit.UpgradeAmount = 0;
        Crit.baselevel = 0;
        Crit.UpdateUpgrade();

        Spread.level = _spreadLevel;
        Spread.UpgradeAmount = 0;
        Spread.baselevel = 0;
        Spread.UpdateUpgrade();

        Freeze.level = _freezeLevel;
        Freeze.UpgradeAmount = 0;
        Freeze.baselevel = 0;
        Freeze.UpdateUpgrade();

        Big.level = _bigLevel;
        Big.UpgradeAmount = 0;
        Big.baselevel = 0;
        Big.UpdateUpgrade();

        Pierce.level = _pierceLevel;
        Pierce.UpgradeAmount = 0;
        Pierce.baselevel = 0;
        Pierce.UpdateUpgrade();  
        #endregion



    }

    private void Update()
    {
        _Level = _levelSystem.level;
        _currentXP = _levelSystem.currentXp;
        _nextLevelXp = _levelSystem.nextLevelXp;
        _xpPoints = _levelSystem.EXPpoints;


        
        _explosionLevel = explosion.level;
        _damageLevel = Damage.level;
        _fireRateLevel = fireRate.level;
        _ricochetLevel = Ricochet.level;
        _speedLevel = SpeedUp.level;
        _duplicateLevel = Duplicate.level;
        _critLevel = Crit.level;
        _spreadLevel = Spread.level;
        _freezeLevel = Freeze.level;
        _bigLevel = Big.level;
        _pierceLevel = Pierce.level; 
        
        

    }
    public void LoadData()
    {
        TutorialCompleted = ES3.Load("TutorialComplete", tutorialDefault);
        EnhancementInfoClosed = ES3.Load("EnhancementInfoClosed", InfoDefault);
        _Level = ES3.Load("SavedLevel", DefaultLevel);
        _currentXP = ES3.Load("SavedXp", DefaultCurrentXp);
        _nextLevelXp = ES3.Load("NextLevelXp", DefaultNextLevelXp);
        _xpPoints = ES3.Load("XPPoints", DefaultXpPoints);

        
        _explosionLevel = ES3.Load("ExplosionUpgradeLevel", DefaultUpgradeLevel);
        _damageLevel = ES3.Load("DamageUpgradeLevel", DefaultUpgradeLevel);
        _fireRateLevel = ES3.Load("FireRateUpgradeLevel", DefaultUpgradeLevel);
        _ricochetLevel = ES3.Load("RicochetUpgradeLevel", DefaultUpgradeLevel);
        _speedLevel = ES3.Load("SpeedUpgradeLevel", DefaultUpgradeLevel);
        _duplicateLevel = ES3.Load("DuplicateUpgradeLevel", DefaultUpgradeLevel);
        _critLevel = ES3.Load("CritUpgradeLevel", DefaultUpgradeLevel);
        _spreadLevel = ES3.Load("SpreadUpgradeLevel", DefaultUpgradeLevel);
        _freezeLevel = ES3.Load("FreezeUpgradeLevel", DefaultUpgradeLevel);
        _bigLevel = ES3.Load("BigUpgradeLevel", DefaultUpgradeLevel);
        _pierceLevel = ES3.Load("PierceUpgradeLevel", DefaultUpgradeLevel);

        ES3.Load("SFXVolume", DefaulAudioValue);
        ES3.Load("MusicVolume", DefaulAudioValue);
        ES3.Load("UIVolume", DefaulAudioValue);
        ResoulutionSet = ES3.Load("Resolution", DefaultResValue);
        QualitySet = ES3.Load("Quality", DefaultQualtityValue);
        FullscreenSet = ES3.Load("FullScreen", DefaultBoolValue);

    }

    public void SaveData()
    {
        ES3.Save("SavedLevel", _Level);
        ES3.Save("SavedXp", _currentXP);
        ES3.Save("NextLevelXp", _nextLevelXp);
        ES3.Save("XPPoints", _xpPoints);

        
        ES3.Save("ExplosionUpgradeLevel", _explosionLevel);
        ES3.Save("DamageUpgradeLevel", _damageLevel);
        ES3.Save("FireRateUpgradeLevel", _fireRateLevel);
        ES3.Save("RicochetUpgradeLevel", _ricochetLevel);
        ES3.Save("SpeedUpgradeLevel", _speedLevel);
        ES3.Save("DuplicateUpgradeLevel", _duplicateLevel);
        ES3.Save("CritUpgradeLevel", _critLevel);
        ES3.Save("SpreadUpgradeLevel", _spreadLevel);
        ES3.Save("FreezeUpgradeLevel", _freezeLevel);
        ES3.Save("BigUpgradeLevel", _bigLevel);
        ES3.Save("PierceUpgradeLevel", _pierceLevel);

        ES3.Save("Resolution", ResoulutionSet);
        ES3.Save("FullScreen", FullscreenSet);
        ES3.Save("Quality", QualitySet);


    }


}
