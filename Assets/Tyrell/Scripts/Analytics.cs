using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameAnalyticsSDK;

public class Analytics : MonoBehaviour
{
    #region singleton
    public static Analytics instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    #endregion

    ////General
    //string WavesCompleted = "Waves Completed";
    //string UpgradesUsed = "Upgrades Used";
    //string ItemsPurchased = "Items Brought";
    
    ////Upgrades
    //string ProSpeedUpgraded = "ProSpeed Upgraded";
    //string ProDamageUpgraded = "ProDamage Upgraded";
    //string FireRateUpgraded = "FireRate Upgraded";
    //string ProjectilesNumUpgraded = "ProjectilesNum Upgraded";
    //string projectileSizeUpgraded = "ProjectilSize Upgraded";
    //string PierceUpgraded = "Pierce Upgraded";
    //string CritChanceUpgraded = "CritChance Upgraded";
    //string RicochetUpgraded = "Ricochet Upgraded";
    //string ExplosionUpgraded = "Explosion Upgraded";


    ////Items
    //string InventorySizeItem = "InventorySizeItem";
    //string MaxHealthItem = "MaxHealthItem";
    //string HealHealthItem = "HealHealthItem";
    //string SpeedItem = "SpeedItem";
    //string IncreaseMoneyItem = "IncreaseMoneyItem";
    //string RandomItem = "RandomItem";
    //string DashCooldownItem = "DashCooldownItem";
    



    ////Player
    //string PlayerMoved = "Player Has Moved";
    //string PlayerStill = "Player Is Still";

    ////Game states
    //string GameStarted = "Game Started";
    //string GameQuit = "Game Quit";
    //string GameCompleted = "Game Complete";

    //public void SendAnalytics()
    //{
    //    GameAnalytics.NewDesignEvent(WavesCompleted, WaveGameManager.instance.WavesCompleted);
    //    GameAnalytics.NewDesignEvent(UpgradesUsed, ItemUpgradeRemove.instance.NumberOfUpgrades);
    //    GameAnalytics.NewDesignEvent(ItemsPurchased, PlayerItemUpgradeRemove.instance.NumberOfPurchases);


    //    //upgrades Used Analytics
    //    GameAnalytics.NewDesignEvent(ProSpeedUpgraded, Upgradeables.instance.ProSpeedUpgraded);
    //    GameAnalytics.NewDesignEvent(ProDamageUpgraded, Upgradeables.instance.ProDamageUpgraded);
    //    GameAnalytics.NewDesignEvent(FireRateUpgraded, Upgradeables.instance.FireRateUpgraded);
    //    GameAnalytics.NewDesignEvent(ProjectilesNumUpgraded, Upgradeables.instance.ProjectilesNumUpgraded);
    //    GameAnalytics.NewDesignEvent(projectileSizeUpgraded, Upgradeables.instance.projectileSizeUpgraded);
    //    GameAnalytics.NewDesignEvent(PierceUpgraded, Upgradeables.instance.PierceUpgraded);
    //    GameAnalytics.NewDesignEvent(CritChanceUpgraded, Upgradeables.instance.CritChanceUpgraded);
    //    GameAnalytics.NewDesignEvent(RicochetUpgraded, Upgradeables.instance.RicochetUpgraded);
    //    GameAnalytics.NewDesignEvent(ExplosionUpgraded, Upgradeables.instance.ExplosionUpgraded);

    //    //Items Brought
    //    GameAnalytics.NewDesignEvent(InventorySizeItem, PlayerItemUpgradeRemove.instance.InventoryItem);
    //    GameAnalytics.NewDesignEvent(MaxHealthItem, PlayerItemUpgradeRemove.instance.MaxHealthItem);
    //    GameAnalytics.NewDesignEvent(HealHealthItem, PlayerItemUpgradeRemove.instance.HealHealthItem);
    //    GameAnalytics.NewDesignEvent(SpeedItem, PlayerItemUpgradeRemove.instance.SpeedItem);
    //    GameAnalytics.NewDesignEvent(RandomItem, PlayerItemUpgradeRemove.instance.RandomItemItem);
    //    GameAnalytics.NewDesignEvent(IncreaseMoneyItem, PlayerItemUpgradeRemove.instance.IncreaseMoneyItem);
    //    GameAnalytics.NewDesignEvent(DashCooldownItem, PlayerItemUpgradeRemove.instance.DashCooldownItem);

    //    //player Movement
    //    GameAnalytics.NewDesignEvent(PlayerMoved, PlayerControllerTest.instance.HowMuchPlayerMoved);
    //    GameAnalytics.NewDesignEvent(PlayerStill, PlayerControllerTest.instance.HowMuchPlayerStill);

    //}

    //public void GameStartAnalytics()
    //{
    //    GameAnalytics.NewProgressionEvent(GAProgressionStatus.Start, GameStarted);
        
    //}

    //public void GameCompletedAnalytics()
    //{
    //    GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, GameCompleted, WaveGameManager.instance.WavesCompleted);
    //}

    //public void GameQuitAnalytics()
    //{
    //    GameAnalytics.NewProgressionEvent(GAProgressionStatus.Fail, GameQuit, WaveGameManager.instance.WavesCompleted);

    //}

}
