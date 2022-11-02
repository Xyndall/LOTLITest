using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    //Scripts
    public Upgradeables stats;
    public SetBonusesCheck SetBonuses;

    //UI Elements
    public TextMeshProUGUI DamageText;
    public TextMeshProUGUI ProSpeedText;
    public TextMeshProUGUI FireRateText;
    public TextMeshProUGUI NumOfProjectiles;
    public TextMeshProUGUI PriceCountText;
    public TextMeshProUGUI RicochetCountText;
    public TextMeshProUGUI CritChance;
    public TextMeshProUGUI FreezeText;
    public TextMeshProUGUI BulletSpreadText;
    public TextMeshProUGUI ExplosionRadiusText;
    public TextMeshProUGUI CritDMGText;

    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.FindWithTag("Player") != null)
        {
            stats = GameObject.FindWithTag("Player").GetComponent<Upgradeables>();
            SetBonuses = GameObject.FindWithTag("Player").GetComponent<SetBonusesCheck>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (stats != null)
        {

            //Gun stats texts
            DamageText.text = "Damage: " + stats.projectileDamage;
            ProSpeedText.text = "Projectile Speed: " + stats.projectileSpeed;
            FireRateText.text = "Fire Rate: " + stats._fireRate;
            NumOfProjectiles.text = "Projectiles: " + stats.NumberOfProjectile;
            CritChance.text = "Crit Chance: " + stats.critChance + "%";
            PriceCountText.text = "Pierce Count: " + stats.PierceCountUpgraded;
            RicochetCountText.text = "Ricochet Count: " + stats.ricochetCountUpgraded;
            FreezeText.text = "Freeze Time: " + stats.FreezeTime;
            BulletSpreadText.text = "Bullet Spread: " + stats.SpreadFactor;
            ExplosionRadiusText.text = "Explosion Radius: " + stats.ExplosionArea;
            CritDMGText.text = "Critical DMG : X" + stats.critDamage;
        }

        


    }
}
