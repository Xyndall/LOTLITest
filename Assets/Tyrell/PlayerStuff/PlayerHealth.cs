using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public Upgradeables upgrade;
    bool playerDead = false;

    bool Invincibility;

    public Renderer[] RendMaterials;
    float HitTime = 0.1f;

    private void Start()
    {
        upgrade.GetComponent<Upgradeables>();
    }

    private void Update()
    {
        if (upgrade.Health <= 0 && !playerDead)
        {
            Debug.Log("Player Died");
            playerDead = true;
            PlayerDied();
            
            
        }

        if (upgrade.Health > upgrade.MaxHealth)
        {
            upgrade.Health = upgrade.MaxHealth;
        }
        
    }

    public void TakeDamage(float amount)
    {
        if (!Invincibility)
        {
            StartCoroutine(SetHit());
            CinemachineShake.Instance.ShakeCamera(5f, 0.2f);
            upgrade.Health -= amount;
            Debug.Log("Player took damage " + amount);
            DamagePopUp.Create(transform.position + (Vector3.up * 4), amount, false);
        }
        
        StartCoroutine(Invincible(0.5f));
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

    public void GainHealth(float amount)
    {
        upgrade.Health += amount;
    }

    IEnumerator Invincible(float length)
    {
        Invincibility = true;
        yield return new WaitForSeconds(length);
        Invincibility = false;
    }

    public void PlayerDied()
    {
        if (PlayerData.TutorialComplete == 0)
        {
            if (FindObjectOfType<TutorialManager>() != null)
                TutorialManager.instance.ShowDeathMSG();
            
        }
        else
        {
            PlayerData.instance.SaveData();
            LoadSceneManager.instance.LoadStartingArea();
        }

        
    }


    IEnumerator Death()
    {
        yield return new WaitForSeconds(2);
    }

    

}
