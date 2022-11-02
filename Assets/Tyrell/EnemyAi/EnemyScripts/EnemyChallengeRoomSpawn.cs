using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChallengeRoomSpawn : EnemyRoomSpawn
{


    [SerializeField]
    private GameObject[] elitePrefabs;

    [SerializeField]
    public List<GameObject> challengeenemyList = new List<GameObject>();


    public GameObject ChallengeItemChoice;



    public override void FixedUpdate()
    {
        enemyList.RemoveAll(GameObject => GameObject == null);
    }

    public override void Start()
    {
        maxEnemySpawn = RoomManager.instance.CalculateEnemySpawns();

        StartCoroutine(ChallengeWaitForPlayer());

    }



    IEnumerator ChallengeWaitForPlayer()
    {
        yield return new WaitForSeconds(2);
        for (int i = 0; i < maxEnemySpawn; i++)
        {
            SpawnEnemies();
        }
        for (int i = 0; i < RoomManager.instance.EliteEnemies; i++)
        {
            SpawnElite();
        }
        
    }

    public override void ShowNewItems()
    {

        ShowItems.instance.ShowItemChoice();
        
        ChallengeItemChoice.SetActive(true);
        ChallengeItemChoice.GetComponent<DropItemChoice>().ShowItems();
        

    }

    void SpawnElite()
    {
        int spawnNum = Random.Range(0, spawnZones.Length);
        int enemyNum = Random.Range(0, elitePrefabs.Length);

        GameObject EnemySpawn = Instantiate(EnemySpawnEffect, spawnZones[spawnNum].transform.position, Quaternion.identity);
        Destroy(EnemySpawn, 3);

        GameObject eliteEnemy = Instantiate(elitePrefabs[enemyNum], spawnZones[spawnNum].transform.position, Quaternion.identity, transform);
        eliteEnemy.GetComponent<EnemyHealth>().MaxHealth += RoomManager.instance.CalculateEnemyHealthScaler();
        eliteEnemy.GetComponent<EnemyHealth>().Health += RoomManager.instance.CalculateEnemyHealthScaler();
        eliteEnemy.GetComponent<EnemyHealth>().XpGiven = RoomManager.instance.difficultyXp + 20;
        eliteEnemy.GetComponent<EnemyAiController>().roomspawn = this;
        eliteEnemy.GetComponent<EnemyAiController>().IsRogueLite = true;
        enemyList.Add(eliteEnemy);
    }


}
