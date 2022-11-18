using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetBonusesCheck : MonoBehaviour
{
    public Upgradeables upgrades;

    [Header("Set Bonuses")]
    public SetBonuses _ArmorPiercer;
    public bool _armorPierceSet = false;
    public SetBonuses _MegaRicochet;
    public bool _megaRicochetSet = false;
    public SetBonuses _ExplosionMagnet;
    public bool _explosionMagnetSet = false;
    public SetBonuses _Seeking;
    public bool _seekingSet = false;
    public SetBonuses _LifeSteal;
    public bool _lifeStealSet = false;
    public SetBonuses _UltraFreeze;
    public bool _ultraFreezeSet = false;
    public SetBonuses _TackShooter;
    public bool _tackShooterSet = false;
    public SetBonuses _CritMaker;
    public bool _critMakerSet = false;
    public SetBonuses _Minigun;
    public bool _minigunSet = false;


    private void Update()
    {
        CheckSetBonuses();

    }


    void CheckSetBonuses()
    {
        #region ArmorPierce
        //Armor Pierce set bonus
        if (upgrades.PierceUpgraded >= 2 && _armorPierceSet == false)
        {
            _ArmorPiercer.setComplete();
            _armorPierceSet = true;
        }
        else if (upgrades.PierceUpgraded < 2 && _armorPierceSet == true)
        {
            _ArmorPiercer.setRemoved();
            _armorPierceSet = false;
        }
        #endregion

        #region MegaRicochet
        //Mega Ricochet Set Bonus
        if (upgrades.RicochetUpgraded >= 2 && upgrades.ProDamageUpgraded >= 1
            && upgrades.ProSpeedUpgraded >= 1 && _megaRicochetSet == false)
        {
            _MegaRicochet.setComplete();
            _megaRicochetSet = true;
        }
        else if ((upgrades.RicochetUpgraded < 2 || upgrades.ProDamageUpgraded < 1
            || upgrades.ProSpeedUpgraded < 1) && _megaRicochetSet == true)
        {
            _MegaRicochet.setRemoved();
            _megaRicochetSet = false;
        }
        #endregion

        #region ExplosionMagnet
        //Explosion Magnet set bonus
        if (upgrades.ExplosionUpgraded >= 4 && _explosionMagnetSet == false)
        {
            _ExplosionMagnet.setComplete();
            _explosionMagnetSet = true;
        }
        else if (upgrades.ExplosionUpgraded < 4 && _explosionMagnetSet == true)
        {
            _ExplosionMagnet.setRemoved();
            _explosionMagnetSet = false;
        }
        #endregion

        #region Seeking
        //Seeking Set Bonus
        if (upgrades.ExplosionUpgraded >= 1 && upgrades.ProSpeedUpgraded >= 2 && _seekingSet == false)
        {
            _Seeking.setComplete();
            _seekingSet = true;
        }
        else if ((upgrades.ExplosionUpgraded < 1 || upgrades.ProSpeedUpgraded < 2) && _seekingSet == true)
        {
            _Seeking.setRemoved();
            _seekingSet = false;
        }
        #endregion

        #region LifeSteal
        //LifeSteal Set bonus
        if (upgrades.ProDamageUpgraded >= 2 && upgrades.ProjectilesNumUpgraded >= 2 && upgrades.projectileSizeUpgraded >= 2
             && _lifeStealSet == false)
        {
            _LifeSteal.setComplete();
            _lifeStealSet = true;
        }
        else if ((upgrades.ProDamageUpgraded < 2 || upgrades.ProjectilesNumUpgraded < 2 || upgrades.projectileSizeUpgraded < 2)
           && _lifeStealSet == true)
        {
            _LifeSteal.setRemoved();
            _lifeStealSet = false;
        }
        #endregion

        #region UltraFreeze
        //UltraFreeze
        if (upgrades.ExplosionUpgraded >= 2 && upgrades.FreezeUpgraded >= 2 && _ultraFreezeSet == false)
        {
            _UltraFreeze.setComplete();
            _ultraFreezeSet = true;
        }
        else if ((upgrades.ExplosionUpgraded < 2 || upgrades.FreezeUpgraded < 2) && _ultraFreezeSet == true)
        {
            _UltraFreeze.setRemoved();
            _ultraFreezeSet = false;
        }
        #endregion

        #region TackShooter
        //TackShooter
        if (upgrades.SpreadUpgraded >= 3 && upgrades.ProjectilesNumUpgraded >= 3 &&
            upgrades.FireRateUpgraded >= 3 && _tackShooterSet == false)
        {
            _TackShooter.setComplete();
            _tackShooterSet = true;
        }
        else if((upgrades.SpreadUpgraded < 3 || upgrades.ProjectilesNumUpgraded < 3 ||
            upgrades.FireRateUpgraded < 3) && _tackShooterSet == true)
        {
            _TackShooter.setRemoved();
            _tackShooterSet = false;
        }

        #endregion

        #region CritChance
        if (upgrades.CritChanceUpgraded >= 7 && _critMakerSet == false)
        {
            _CritMaker.setComplete();
            _critMakerSet = true;
        }
        else if (upgrades.CritChanceUpgraded < 7 && _critMakerSet == true)
        {
            _CritMaker.setRemoved();
            _critMakerSet = false;
        }
        #endregion

        #region Minigun
        if (upgrades.FireRateUpgraded >= 3 && upgrades.SpreadUpgraded >= 1 && _minigunSet == false)
        {
            _Minigun.setComplete();
            _minigunSet = true;
        }
        else if ((upgrades.FireRateUpgraded < 3 || upgrades.SpreadUpgraded < 1) && _minigunSet == true)
        {
            _Minigun.setRemoved();
            _minigunSet = false;
        }
        #endregion

    }

}
