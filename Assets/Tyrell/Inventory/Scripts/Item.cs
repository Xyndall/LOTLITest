using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "Item", menuName = "Item/baseItem")]
public class Item : ScriptableObject
{
    new public string name = "Defulat Item";
    public Sprite icon = null;
    public string itemDescription = "Used for projectile";
    public string itemUpgradeDescription = "Upgrade upgrade";

    public ItemType itemType;
    public float amount;
    public float Rarity;
    public float UpgradeAmount;
    public float AddedAmount;
    public float baselevel = 0;
    public int level;
    public int maxLevel;
    public int Cost;

   public void Upgrade()
    {
        if(level < maxLevel)
            level++;

    }

    public void UpdateUpgrade()
    {
        if (level > baselevel)
        {
            while (level > baselevel)
            {
                UpgradeAmount += AddedAmount;
                baselevel++;

                if (level == baselevel)
                    break;
            }
        }
    }

    public virtual void Use()
    {
        Debug.Log("Using " + name);
        ItemUpgradeRemove.instance.OnStatItemUse(itemType, amount, UpgradeAmount);
    }

    public virtual void Remove()
    {
        Debug.Log("Removing " + name);
        ItemUpgradeRemove.instance.OnStatItemRemove(itemType, amount, UpgradeAmount);
    }

    public virtual string GetItemDescription()
    {
        return itemDescription;
    }

    public virtual string GetItemUpgradeDescription()
    {
        return itemUpgradeDescription;
    }

}

public enum ItemType
{
    FireRate,
    Damage,
    ProjectileSpeed,
    NumOfProjectiles,
    ProjectileSize,
    Ricochet,
    DoubleDamage,
    SeekingProjectiles,
    ProjectilePierce,
    CritChance,
    ImpactExplosion,
    Freeze,
    IncreaseSpread,
    DecreaseSpreaad,




}
