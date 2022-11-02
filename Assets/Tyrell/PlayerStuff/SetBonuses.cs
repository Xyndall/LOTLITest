using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "SetBonuses", menuName = "SetBonuses/SetBonus")]
public class SetBonuses : ScriptableObject
{
    new public string name = "Defulat Bonus";
    public Sprite icon = null;
    public string itemDescription = "Used for projectile";

    public BonusType bonusType;
    public float amount;

    public void setComplete()
    {
        SetBonusesActive.instance.OnSetComplete(bonusType, amount);
        Debug.Log("Completed " + bonusType);
    }

    public void setRemoved()
    {
        SetBonusesActive.instance.OnSetRemoved(bonusType, amount);
        Debug.Log("Removed " + bonusType);
    }

    public virtual string GetItemDescription()
    {
        return itemDescription;
    }

}


public enum BonusType
{
    ArmorPiercer,
    MegaRicochet,
    ExplosiveMagnet,
    Seeking,
    LifeSteal,
    UltraFreeze,
    TackShooter,
    CritMaker,
    Minigun,









}
