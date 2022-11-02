using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetBonusUI : MonoBehaviour
{
    #region singleton
    public static SetBonusUI instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    #endregion

    public GameObject FreezeIcon;
    public GameObject FireIcon;
    public GameObject MegaIcon;
    public GameObject LifeStealIcon;
    public GameObject ArmorPierceIcon;
    public GameObject SeekingIcon;
    public GameObject TackShooterIcon;
    public GameObject CritMakerIcon;
    public GameObject MinigunIcon;

    GameObject newfreeze;
    GameObject newFire;
    GameObject newMega;
    GameObject newLifeSteal;
    GameObject newArmorPierce;
    GameObject newSeeking;
    GameObject newTackShooter;
    GameObject newCritMaker;
    GameObject newMinigun;


    public void CompleteSetIcon(BonusType bonusType)
    {
        switch (bonusType)
        {
            case BonusType.ArmorPiercer:
                newArmorPierce = Instantiate(ArmorPierceIcon, transform);
                break;

            case BonusType.MegaRicochet:
                newMega = Instantiate(MegaIcon, transform);
                break;

            case BonusType.ExplosiveMagnet:
                newFire = Instantiate(FireIcon, transform);
                break;

            case BonusType.Seeking:
                newSeeking = Instantiate(SeekingIcon, transform);
                break;

            case BonusType.LifeSteal:
                newLifeSteal = Instantiate(LifeStealIcon, transform);
                break;

            case BonusType.UltraFreeze:
                newfreeze = Instantiate(FreezeIcon, transform);
                break;

            case BonusType.TackShooter:
                newTackShooter = Instantiate(TackShooterIcon, transform);
                break;

            case BonusType.CritMaker:
                newCritMaker = Instantiate(CritMakerIcon, transform);
                break;

            case BonusType.Minigun:
                newMinigun = Instantiate(MinigunIcon, transform);
                break;

        }
    }

    public void RemoveSetIcon(BonusType bonusType)
    {
        switch (bonusType)
        {
            case BonusType.ArmorPiercer:
                Destroy(newArmorPierce);
                break;

            case BonusType.MegaRicochet:
                Destroy(newMega);
                break;

            case BonusType.ExplosiveMagnet:
                Destroy(newFire);
                break;

            case BonusType.Seeking:
                Destroy(newSeeking);
                break;

            case BonusType.LifeSteal:
                Destroy(newLifeSteal);
                break;

            case BonusType.UltraFreeze:
                Destroy(newfreeze);
                break;

            case BonusType.TackShooter:
                Destroy(newTackShooter);
                break;

            case BonusType.CritMaker:
                Destroy(newCritMaker);
                break;

            case BonusType.Minigun:
                Destroy(newMinigun);
                break;
        }
    }
    

}
