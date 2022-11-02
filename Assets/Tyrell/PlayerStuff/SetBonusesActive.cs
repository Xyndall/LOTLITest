using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetBonusesActive : MonoBehaviour
{
    #region singleton
    public static SetBonusesActive instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    #endregion

    public Upgradeables upgrade;



    public void OnSetComplete(BonusType bonusType, float amount )
    {

        switch (bonusType)
        {
            case BonusType.ArmorPiercer:
                ArmorPiercer();
                SetBonusUI.instance.CompleteSetIcon(bonusType);
                break;

            case BonusType.MegaRicochet:
                MegaRicochet();
                SetBonusUI.instance.CompleteSetIcon(bonusType);
                break;

            case BonusType.ExplosiveMagnet:
                ExplosionMagnet();
                SetBonusUI.instance.CompleteSetIcon(bonusType);
                break;

            case BonusType.Seeking:
                Seeking();
                SetBonusUI.instance.CompleteSetIcon(bonusType);
                break;

            case BonusType.LifeSteal:
                LifeSteal();
                SetBonusUI.instance.CompleteSetIcon(bonusType);
                break;

            case BonusType.UltraFreeze:
                UltraFreeze();
                SetBonusUI.instance.CompleteSetIcon(bonusType);
                break;

            case BonusType.TackShooter:
                TackShooter(amount);
                SetBonusUI.instance.CompleteSetIcon(bonusType);
                break;

            case BonusType.CritMaker:
                CritMaker();
                SetBonusUI.instance.CompleteSetIcon(bonusType);
                break;

            case BonusType.Minigun:
                Minigun(amount);
                SetBonusUI.instance.CompleteSetIcon(bonusType);
                break;

        }
        
    }

    public void OnSetRemoved(BonusType bonusType, float amount  )
    {
        switch (bonusType)
        {
            case BonusType.ArmorPiercer:
                RemoveArmorPiercer();
                SetBonusUI.instance.RemoveSetIcon(bonusType);
                break;

            case BonusType.MegaRicochet:
                RemoveMegaRicochet();
                SetBonusUI.instance.RemoveSetIcon(bonusType);
                break;

            case BonusType.ExplosiveMagnet:
                RemoveExplosionMagnet();
                SetBonusUI.instance.RemoveSetIcon(bonusType);
                break;

            case BonusType.Seeking:
                RemoveSeeking();
                SetBonusUI.instance.RemoveSetIcon(bonusType);
                break;

            case BonusType.LifeSteal:
                RemoveLifeSteal();
                SetBonusUI.instance.RemoveSetIcon(bonusType);
                break;

            case BonusType.UltraFreeze:
                RemoveUltraFreeze();
                SetBonusUI.instance.RemoveSetIcon(bonusType);
                break;

            case BonusType.TackShooter:
                RemoveTackShooter(amount);
                SetBonusUI.instance.RemoveSetIcon(bonusType);
                break;

            case BonusType.CritMaker:
                RemoveCritMaker();
                SetBonusUI.instance.RemoveSetIcon(bonusType);
                break;

            case BonusType.Minigun:
                RemoveMinigun(amount);
                SetBonusUI.instance.RemoveSetIcon(bonusType);
                break;

        }

    }

    #region Armor
    public void ArmorPiercer()
    {
        upgrade.ArmorPiercer = true;

    }
    public void RemoveArmorPiercer()
    {
        upgrade.ArmorPiercer = false;

    }
    #endregion

    #region Ricochet
    public void MegaRicochet()
    {
        Debug.Log("Mega Ricochet");
        upgrade.MegaRicochet = true;

    }
    public void RemoveMegaRicochet()
    {
        Debug.Log("Mega Ricochet Removed");
        upgrade.MegaRicochet = false;

    } 
    #endregion

    public void ExplosionMagnet()
    {
        Debug.Log("Explosive Magnet");
        upgrade.ExplosionMagnet = true;
        
    }
    public void RemoveExplosionMagnet()
    {
        Debug.Log("Explosive Magnet Removed");
        upgrade.ExplosionMagnet = false;
        
    }

    public void Seeking()
    {
        Debug.Log("Seeking");
        upgrade.Seeking = true;
        
    }
    public void RemoveSeeking()
    {
        Debug.Log("Removed Seeking");
        upgrade.Seeking = false;
        
    }

    public void LifeSteal()
    {
        Debug.Log("Life Steal");
        upgrade.LifeSteal = true;
        
    }
    public void RemoveLifeSteal()
    {
        Debug.Log("Remove Life Steal");
        upgrade.LifeSteal = false;
        
    }

    public void UltraFreeze()
    {
        Debug.Log("Ultra freeze");
        upgrade.UltraFreeze = true;
        
    }
    public void RemoveUltraFreeze()
    {
        Debug.Log("Remove Ultra freeze");
        upgrade.UltraFreeze = false;
        
    }

    public void TackShooter(float amount)
    {
        Debug.Log("Tack Shooter");
        upgrade.TackShooter = true;
        upgrade.TackShooterUpgrade(amount);
    }
    public void RemoveTackShooter(float amount)
    {
        Debug.Log("Remove Tack Shooter");
        upgrade.TackShooter = false;
        upgrade.TackShooterRemove(amount);
    }


    #region CritMaker

    public void CritMaker()
    {
        Debug.Log("Crit Maker");
        upgrade.CritMaker = true;
        upgrade.CritMakerUpgrade();
    }
    public void RemoveCritMaker()
    {
        Debug.Log("Remove Crit Maker");
        upgrade.CritMaker = false;
        upgrade.CritMakerRemove();
    }


    #endregion

    #region Minigun
    public void Minigun(float amount)
    {
        Debug.Log("Minigun");
        upgrade.Minigun = true;
        upgrade.MinigunUpgrade(amount);
    }
    public void RemoveMinigun(float amount)
    {
        Debug.Log("Remove Minigun");
        upgrade.Minigun = false;
        upgrade.MinigunRemove(amount);
    }


    #endregion

}
