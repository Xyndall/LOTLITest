using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemUpgradeRemove : MonoBehaviour
{
    #region singleton
    public static ItemUpgradeRemove instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    #endregion

    public int NumberOfUpgrades;
    public Upgradeables upgrade;

    private void Start()
    {
        if (GameObject.FindWithTag("Player") != null)
        {
            upgrade = GameObject.FindWithTag("Player").GetComponent<Upgradeables>();
            Debug.Log("ItemUpgrade found " + upgrade);
        }

    }

    public void OnStatItemUse(ItemType itemType, float amount, float upgradeAmount)
    {
        NumberOfUpgrades++;
        upgrade.GetComponent<Upgradeables>();
        Debug.Log("Upgrade " + itemType + " by " + amount);
        switch (itemType)
        {
            case ItemType.FireRate:
                upgrade.UpgradeFireRate(amount, upgradeAmount);
                break;

            case ItemType.Damage:
                upgrade.UpgradeProjectileDamage(amount, upgradeAmount);
                break;

            case ItemType.ProjectileSpeed:
                upgrade.UpgradeProjectileSpeed(amount, upgradeAmount);
                break;

            case ItemType.NumOfProjectiles:
                upgrade.UpgradeNumOfProjectiles(amount, upgradeAmount);
                break;

            case ItemType.ProjectileSize:
                upgrade.UpgradeProjectileSize(amount, upgradeAmount);
                break;

            case ItemType.ProjectilePierce:
                upgrade.UpgradePierceCount(amount, upgradeAmount);
                break;

            case ItemType.CritChance:
                upgrade.UpgradeCritChance(amount, upgradeAmount);
                break;

            case ItemType.Ricochet:
                upgrade.UpgradeRicochet(amount, upgradeAmount);
                break;

            case ItemType.ImpactExplosion:
                upgrade.UpgradeImpactExpolosion(amount, upgradeAmount);
                break;

            case ItemType.Freeze:
                upgrade.UpgradeFreezeProjectiles(amount, upgradeAmount);
                break;

            case ItemType.IncreaseSpread:
                upgrade.UpgradesSpreadFactor(amount, upgradeAmount);
                break;
        }
    }

    public void OnStatItemRemove(ItemType itemType, float amount, float upgradeAmount)
    {
        NumberOfUpgrades--;
        upgrade.GetComponent<Upgradeables>();
        Debug.Log("Remove " + itemType + " by " + amount);
        switch (itemType)
        {
            case ItemType.FireRate:
                upgrade.RemoveUpgradeFireRate(amount, upgradeAmount);
                break;

            case ItemType.Damage:
                upgrade.RemoveUpgradeProjectileDamage(amount, upgradeAmount);
                break;

            case ItemType.ProjectileSpeed:
                upgrade.RemoveUpgradeProjectileSpeed(amount, upgradeAmount);
                break;

            case ItemType.NumOfProjectiles:
                upgrade.RemoveUpgradeNumOfProjectiles(amount, upgradeAmount);
                break;

            case ItemType.ProjectileSize:
                upgrade.RemoveProjectileSize(amount, upgradeAmount);
                break;

            case ItemType.ProjectilePierce:
                upgrade.RemovePierceCount(amount, upgradeAmount);
                break;

            case ItemType.CritChance:
                upgrade.RemoveCritChance(amount, upgradeAmount);
                break;

            case ItemType.Ricochet:
                upgrade.RemoveRicochet(amount, upgradeAmount);
                break;

            case ItemType.ImpactExplosion:
                upgrade.RemoveImpactExplosion(amount, upgradeAmount);
                break;

            case ItemType.Freeze:
                upgrade.RemoveFreezeProjectiles(amount, upgradeAmount);
                break;

            case ItemType.IncreaseSpread:
                upgrade.RemoveSpreadFactor(amount, upgradeAmount);
                break;
        }
    }
}
