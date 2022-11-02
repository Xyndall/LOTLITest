using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgradeables : MonoBehaviour
{
    #region singleton
    public static Upgradeables instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    #endregion

    #region KeepsTrackOfUpgrades

    //upgrade Analytics values
    [HideInInspector] public int NumberOfUpgrades = 0;
    [HideInInspector] public int ProSpeedUpgraded = 0;
    [HideInInspector] public int ProDamageUpgraded = 0;
    [HideInInspector] public int FireRateUpgraded = 0;
    [HideInInspector] public int ProjectilesNumUpgraded = 0;
    [HideInInspector] public int projectileSizeUpgraded = 0;
    [HideInInspector] public int PierceUpgraded = 0;
    [HideInInspector] public int CritChanceUpgraded = 0;
    [HideInInspector] public int RicochetUpgraded = 0;
    [HideInInspector] public int ExplosionUpgraded = 0;
    [HideInInspector] public int FreezeUpgraded = 0;
    [HideInInspector] public int SpreadUpgraded = 0;

    #endregion


    #region SetBonus

    [Header("SetBonuses")]
    //Set bonuses
    [HideInInspector] public bool ArmorPiercer;
    [HideInInspector] public bool MegaRicochet;
    [HideInInspector] public bool ExplosionMagnet;
    [HideInInspector] public bool Seeking;
    [HideInInspector] public bool LifeSteal;
    [HideInInspector] public bool UltraFreeze;
    [HideInInspector] public bool TackShooter;
    [HideInInspector] public bool CritMaker;
    [HideInInspector] public bool Minigun;

    #endregion


    //gets the highest used upgrade the player is using
    [HideInInspector] public string UpgradeUsedMost;
    [HideInInspector] public int MostUsedUpgrade;

    #region UpgradeValues

    //upgrade values
    [Header("Upgrade values")]
    public float projectileSpeed = 700;

    public int projectileDamage = 10;
    public int projectileBaseDamage = 10;

    public float critChance = 0;
    public float critDamage = 2;

    public float _fireRate = 1;

    public float _nextFire;

    public int NumberOfProjectile = 1;

    public Vector3 ProjectileSize = new Vector3(0.5f, 0.5f, 0.5f);

    public float ProjectileLifeTime = 5;

    public float PierceCountUpgraded = 0;

    public bool Ricochet = false;
    public int ricochetCountUpgraded = 0;

    public float ExplosionArea = 0;
    public int explosiveCountUpgraded = 0;

    public float FreezeTime = 0;

    public float SpreadFactor = 15;

    #endregion

    #region PlayerValues

    //Player values

    [Header("Player values")]
    public float Health = 100;
    public float MaxHealth = 100;
    public float sliderHealthVal;

    public float playerSpeed = 15;

    public float _dashSpeed = 40f;
    public float _dashTime = 0.25f;
    public float _dashCooldownTime = 3;

    public float ItemDropChance = 10;
    public int dropchanceincrease = 100; 

    #endregion



    //scripts
    [Header("Script Refrences")]
    public GunInventoryController gunInventoryController;
    public MoneyManager moneyManager;
    public PlayerHealth pHealth;

    private void Start()
    {
        gunInventoryController = FindObjectOfType<GunInventoryController>(transform);
    }

    private void Update()
    {
        sliderHealthVal = CalculateHealth();

    }

    float CalculateHealth()
    {
        return Health / MaxHealth;
    }

    //Needs work in order to calculate better scaleability;
    float CalculatePercentageUpgrades(float amount, float upgradeAmount)
    {
        amount = amount + upgradeAmount;

        return amount;
    }


    #region SetBonus
    public void TackShooterUpgrade(float amount)
    {
        NumberOfProjectile += (int)amount;
        SpreadFactor += amount;
        _fireRate = _fireRate / amount;
    }
    public void TackShooterRemove(float amount)
    {
        NumberOfProjectile -= (int)amount;
        SpreadFactor -= amount;
        _fireRate = _fireRate * amount;
    }

    public void CritMakerUpgrade()
    {
        critChance += 50;
    }
    public void CritMakerRemove()
    {
        critChance -= 50;
    }

    public void MinigunUpgrade(float amount)
    {
        _fireRate = _fireRate / amount;
    }
    public void MinigunRemove(float amount)
    {
        _fireRate = _fireRate * amount;
    }

    #endregion


    #region GunUpgrades


    //*------- Gun Upgrades --------*//

    #region ProjectileSpeed
    //Projectile speed upgrade
    public void UpgradeProjectileSpeed(float amount, float upgradeAmount)
    {
        ProSpeedUpgraded++;
        projectileSpeed = projectileSpeed + (amount * (1 + upgradeAmount));

        projectileDamage = Mathf.RoundToInt(projectileDamage * (1 + upgradeAmount));
        projectileBaseDamage = Mathf.RoundToInt(projectileBaseDamage * (1 + upgradeAmount));
    }
    public void RemoveUpgradeProjectileSpeed(float amount, float upgradeAmount)
    {
        ProSpeedUpgraded--;
        projectileSpeed = projectileSpeed - (amount * (1 + upgradeAmount));

        projectileDamage = Mathf.RoundToInt(projectileDamage / (1 + upgradeAmount));
        projectileBaseDamage = Mathf.RoundToInt(projectileBaseDamage / (1 + upgradeAmount));
    }
    #endregion

    #region ProjectileDamage
    //Projectile Damage upgrade
    public void UpgradeProjectileDamage(float amount, float upgradeAmount)
    {
        ProDamageUpgraded++;
        projectileDamage = Mathf.RoundToInt(projectileDamage * (amount + upgradeAmount));
        projectileBaseDamage = Mathf.RoundToInt(projectileBaseDamage * (amount + upgradeAmount));

    }
    public void RemoveUpgradeProjectileDamage(float amount, float upgradeAmount)
    {
        ProDamageUpgraded--;
        projectileDamage = Mathf.RoundToInt(projectileDamage / (amount + upgradeAmount));
        projectileBaseDamage = Mathf.RoundToInt(projectileBaseDamage / (amount + upgradeAmount));
    }
    #endregion

    #region FireRate
    //Fire Rate upgrades
    public void UpgradeFireRate(float amount, float upgradeAmount)
    {

        _fireRate = _fireRate / (amount + upgradeAmount);

        FireRateUpgraded++;
    }
    public void RemoveUpgradeFireRate(float amount, float upgradeAmount)
    {
        _fireRate = _fireRate * (amount + upgradeAmount);
        FireRateUpgraded--;

    }
    #endregion

    #region Duplicate
    //increase amount of Projectiles upgrade
    public void UpgradeNumOfProjectiles(float amount, float upgradeAmount)
    {
        ProjectilesNumUpgraded++;
        NumberOfProjectile = NumberOfProjectile + (int)(amount + upgradeAmount);
    }
    public void RemoveUpgradeNumOfProjectiles(float amount, float upgradeAmount)
    {
        ProjectilesNumUpgraded--;
        NumberOfProjectile = NumberOfProjectile - (int)(amount + upgradeAmount);
    }
    #endregion

    #region ProjectileSize
    //ProjectileSize upgrades
    public void UpgradeProjectileSize(float amount, float upgradeAmount)
    {
        projectileSizeUpgraded++;
        Vector3 Size = ProjectileSize;
        Size.x = Size.x + amount + upgradeAmount;
        Size.y = Size.y + amount + upgradeAmount;
        Size.z = Size.z + amount + upgradeAmount;


        ProjectileSize = Size;

        projectileDamage = Mathf.RoundToInt(projectileDamage * (1 + upgradeAmount));
        projectileBaseDamage = Mathf.RoundToInt(projectileBaseDamage * (1 + upgradeAmount));

    }
    public void RemoveProjectileSize(float amount, float upgradeAmount)
    {
        projectileSizeUpgraded--;
        Vector3 Size = ProjectileSize;
        Size.x = Size.x - amount - upgradeAmount;
        Size.y = Size.y - amount - upgradeAmount;
        Size.z = Size.z - amount - upgradeAmount;


        ProjectileSize = Size;

        projectileDamage = Mathf.RoundToInt(projectileDamage / (1 + upgradeAmount));
        projectileBaseDamage = Mathf.RoundToInt(projectileBaseDamage / (1 + upgradeAmount));
    }
    #endregion

    #region Pierce
    //Upgrade Pierce
    public void UpgradePierceCount(float amount, float upgradeAmount)
    {
        PierceUpgraded++;
        PierceCountUpgraded += (int)(amount + upgradeAmount);
    }
    public void RemovePierceCount(float amount, float upgradeAmount)
    {
        PierceUpgraded--;
        PierceCountUpgraded -= (int)(amount + upgradeAmount);
    }
    #endregion


    #region CritChance
    //Crit Chance
    public void UpgradeCritChance(float amount, float upgradeAmount)
    {

        if (CritChanceUpgraded <= 4)
            critChance += amount;


        critDamage +=  upgradeAmount;
        CritChanceUpgraded++;
    }
    public void RemoveCritChance(float amount, float upgradeAmount)
    {

        if (CritChanceUpgraded <= 5)
            critChance -= amount;

        critDamage -= upgradeAmount;
        CritChanceUpgraded--;
    }
    #endregion

    #region Ricochet
    //Ricochet
    public void UpgradeRicochet(float amount, float upgradeAmount)
    {
        RicochetUpgraded++;
        Ricochet = true;
        ricochetCountUpgraded += (int)(amount + upgradeAmount);
    }
    public void RemoveRicochet(float amount, float upgradeAmount)
    {
        RicochetUpgraded--;
        Ricochet = false;
        ricochetCountUpgraded -= (int)(amount + upgradeAmount);
    }
    #endregion

    #region ImpactExplosion
    //Impact Explosion
    public void UpgradeImpactExpolosion(float amount, float upgradeamount)
    {
        ExplosionUpgraded++;
        ExplosionArea += amount + upgradeamount;
        explosiveCountUpgraded++;
    }
    public void RemoveImpactExplosion(float amount, float upgradeamount)
    {
        ExplosionUpgraded--;

        ExplosionArea -= amount + upgradeamount;
        explosiveCountUpgraded--;
    }
    #endregion

    #region Freeze
    //freeze
    public void UpgradeFreezeProjectiles(float amount, float upgradeAmount)
    {
        FreezeTime += amount + upgradeAmount;
        FreezeUpgraded++;
    }
    public void RemoveFreezeProjectiles(float amount, float upgradeAmount)
    {
        FreezeTime -= amount + upgradeAmount;
        FreezeUpgraded--;
    } 
    #endregion

    #region Spread
		//Spread Factor
    public void UpgradesSpreadFactor(float amount, float upgradeAmount)
    {
        SpreadUpgraded++;
        SpreadFactor += amount;

        projectileDamage = Mathf.RoundToInt(projectileDamage * (1 + upgradeAmount));
        projectileSpeed = projectileSpeed * (1 + upgradeAmount);
        _fireRate = _fireRate / (1 + upgradeAmount);
        ProjectileSize = new Vector3(ProjectileSize.x * (1 + upgradeAmount), ProjectileSize.y * (1 + upgradeAmount)
            , ProjectileSize.z * (1 + upgradeAmount));


    }
    public void RemoveSpreadFactor(float amount, float upgradeAmount)
    {
        SpreadUpgraded--;
        SpreadFactor -= amount;

        projectileDamage = Mathf.RoundToInt(projectileDamage / (1 + upgradeAmount));
        projectileSpeed = projectileSpeed / (1 + upgradeAmount);
        _fireRate = _fireRate * (1 + upgradeAmount);
        ProjectileSize = new Vector3(ProjectileSize.x / (1 + upgradeAmount), ProjectileSize.y / (1 + upgradeAmount)
            , ProjectileSize.z / (1 + upgradeAmount));
    } 
    #endregion


    //*------- Gun Upgrades --------*//


    #endregion

    #region PlayerUpgrades

    //*------- Player upgrades --------*//

    //Gun Inventory
    public void UpgradeGunInventory()
    {
        gunInventoryController.AddGunInventorySlot();
    }


    //MaxHealth
    public void UpgradeMaxHealth(float amount)
    {
        MaxHealth += amount;
    }

    //Heal
    public void HealHealth()
    {
        Health = MaxHealth;
    }

    //Speed
    public void UpgradeSpeed(float amount)
    {
        playerSpeed = playerSpeed * amount;
    }

    //money Gain
    public void UpgradeMoney(float amount)
    {
        moneyManager.IncreaseMoney(amount);
    }

    //Give Random Item
    public void RandomItem()
    {
        Item newItem = GameManager.instance.GunItemList[Random.Range(0, GameManager.instance.GunItemList.Count)];

        Inventory.instance.AddItemToGun(Instantiate(newItem));
    }

    //Dash Cooldown
    public void DashCooldown(float amount)
    {
        _dashCooldownTime -= amount;
    }

    //*------- Player upgrades --------*// 
    #endregion


}
