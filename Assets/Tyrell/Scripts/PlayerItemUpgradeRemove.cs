using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItemUpgradeRemove : MonoBehaviour
{
    #region singleton
    public static PlayerItemUpgradeRemove instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    #endregion

    public int NumberOfPurchases;

    public Upgradeables upgrade;


    [HideInInspector] public int InventoryItem = 0;
    [HideInInspector] public int MaxHealthItem = 0;
    [HideInInspector] public int HealHealthItem = 0;
    [HideInInspector] public int SpeedItem = 0;
    [HideInInspector] public int RandomItemItem = 0;
    [HideInInspector] public int IncreaseMoneyItem = 0;
    [HideInInspector] public int DashCooldownItem= 0;
    


    private void Start()
    {
        if (GameObject.FindWithTag("Player") != null)
        {
            upgrade = GameObject.FindWithTag("Player").GetComponent<Upgradeables>();
            Debug.Log("PlayerItemUpgrade found " + upgrade);
        }

    }

    public void OnStatItemUse(DropItemType itemType, float amount)
    {
        NumberOfPurchases++;
        upgrade.GetComponent<Upgradeables>();
        Debug.Log("Upgrade" + itemType + " by " + amount);
        switch (itemType)
        {
            case DropItemType.ExtraInventorySlot:
                upgrade.UpgradeGunInventory();
                InventoryItem++;
                break;
            case DropItemType.MaxHealth:
                upgrade.UpgradeMaxHealth(amount);
                MaxHealthItem++;
                break;
            case DropItemType.HealHealth:
                upgrade.HealHealth();
                HealHealthItem++;
                break;
            case DropItemType.Speed:
                upgrade.UpgradeSpeed(amount);
                SpeedItem++;
                break;
            case DropItemType.RandomItem:
                upgrade.RandomItem();
                RandomItemItem++;
                break;
            case DropItemType.IncreaseMoneyGain:
                upgrade.UpgradeMoney(amount);
                IncreaseMoneyItem++;
                break;
            case DropItemType.DashCooldown:
                upgrade.DashCooldown(amount);
                DashCooldownItem++;
                break;



        }
    }

   
}
