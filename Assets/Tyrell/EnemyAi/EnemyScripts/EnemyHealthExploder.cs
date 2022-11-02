using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthExploder : EnemyHealth
{
    public EnemyExploder explode;

    public override void EnemyKilled(string Name)
    {
        explode.CheckForPlayer();
        GameObject enemyDeathParticle = Instantiate(EnemyDeathParticle, transform.position, Quaternion.identity);
        enemyDeathParticle.GetComponent<EnemyDeathParticle>().newColor = customColor;
        Destroy(enemyDeathParticle, 2);


        AchievementManager.instance.AddAchievementProgress(Name, 1);
        LevelSystem.instance.GainExperienceScalable(XpGiven, LevelSystem.instance.level);
        MoneyManager.instance.DropMoney();
        AiController.DestroyEnemy();
    }




}
