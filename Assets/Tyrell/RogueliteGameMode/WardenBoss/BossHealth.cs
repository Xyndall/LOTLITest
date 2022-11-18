using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BossHealth : MonoBehaviour
{

    public float Health = 100;
    public float MaxHealth = 100;

    public float XpGiven = 500;

    public TextMeshProUGUI Name;
    public Slider HealthBar;

    public GameObject EnemyDeathParticle;
    public Color customColor;

    public Renderer[] RendMaterials;
    float HitTime = 0.1f;

    public bool isKraken = false;

    private void Update()
    {
        HealthBar.value = CalculateHealth();

        if (Health <= 0)
        {
            EnemyKilled("BossKilled");
            
        }
    }

    private void Start()
    {
        CinemachineZoom.Instance.ZoomOut();
    }

    void EnemyKilled(string Name)
    {
        GameObject enemyDeathParticle = Instantiate(EnemyDeathParticle, transform.position, Quaternion.identity);
        enemyDeathParticle.GetComponent<EnemyDeathParticle>().newColor = customColor;
        Destroy(enemyDeathParticle, 2);

        AchievementManager.instance.AddAchievementProgress(Name, 1);
        LevelSystem.instance.GainExperienceScalable(XpGiven, LevelSystem.instance.level);
        MoneyManager.instance.DropMoney();
        DestroyWardenBoss();
    }

    public void EnemyTakeDamage(float amount, bool isCrit)
    {
        StartCoroutine(SetHit());
        Health -= amount;
        float damageSpawn = Random.Range(0, 4);
        Vector3 enemyPos = new Vector3(transform.position.x + damageSpawn, transform.position.y + 15, transform.position.z);
        DamagePopUp.Create(enemyPos, amount, isCrit);
    }

    IEnumerator SetHit()
    {
        Color customColor = new Color(0.9245283f, 0.3968494f, 0.3968494f, 1);
        Color DefaultColor = new Color(0.7f, 0.7f, 0.7f, 1);
        foreach (Renderer mats in RendMaterials)
        {
            mats.GetComponent<Renderer>().material.SetColor("_BaseColor", customColor);
            mats.GetComponent<Renderer>().material.SetColor("_1st_ShadeColor", customColor);
        }


        yield return new WaitForSeconds(HitTime);


        foreach (Renderer mats in RendMaterials)
        {
            mats.GetComponent<Renderer>().material.SetColor("_BaseColor", DefaultColor);
            mats.GetComponent<Renderer>().material.SetColor("_1st_ShadeColor", DefaultColor);
        }

    }

    public void DestroyWardenBoss()
    {
        PlayerData.instance.SaveData();
        Destroy(gameObject);
        if (isKraken)
        {
            StartCoroutine(WaitForSave());
        }
    }

    IEnumerator WaitForSave()
    {

        yield return new WaitForSeconds(5);

        CinemachineZoom.Instance.ZoomIn();
        LoadSceneManager.instance.LoadCredits();

    }
    
    

    float CalculateHealth()
    {
        return Health / MaxHealth;
    }

}
