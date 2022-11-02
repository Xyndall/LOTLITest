using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
[CreateAssetMenu(fileName = "Item", menuName = "Item/DropItem")]
public class ItemDrop : ScriptableObject
{
    new public string name = "Defulat Item";
    public Sprite icon = null;
    public string itemDescription = "Upgrade Player stats";

    public DropItemType dropItemType;
    public float amount;
    public int ItemCost;

    

    public virtual void Use()
    {
        PlayerItemUpgradeRemove.instance.OnStatItemUse(dropItemType, amount);
    }


    public virtual string GetItemDescription()
    {
        return itemDescription;
    }
}


public enum DropItemType
{
    ExtraInventorySlot,
    MaxHealth,
    HealHealth,
    Speed,
    RandomItem,
    IncreaseMoneyGain,
    DashCooldown,


}