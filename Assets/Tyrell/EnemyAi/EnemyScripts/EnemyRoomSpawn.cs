using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRoomSpawn : MonoBehaviour
{
    #region singleton
    public static EnemyRoomSpawn instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    #endregion



    public Transform[] spawnZones; // Array filled with spawn zones transform

    public GameObject[] enemyPrefabs; // All available enemy prefabs stored here


    public List<GameObject> enemyList = new List<GameObject>();


    public int maxEnemySpawn;

    public GameObject EnemySpawnEffect;

    public virtual void FixedUpdate()
    {
        enemyList.RemoveAll(GameObject => GameObject == null);
    }

    public virtual void Start()
    {
        

        maxEnemySpawn = RoomManager.instance.CalculateEnemySpawns();

        StartCoroutine(WaitForPlayer());
        
    }



    IEnumerator WaitForPlayer()
    {
        yield return new WaitForSeconds(2);
        for (int i = 0; i < maxEnemySpawn; i++)
        {
            SpawnEnemies();
        }
    }

    public void RemoveEnemy(GameObject enemy)
    {
        enemyList.Remove(enemy);
        if (enemyList.Count <= 0)
        {

            ShowNewItems();
        }
        
    }

    public virtual void ShowNewItems()
    {
        ShowItems.instance.ShowItemChoice();
    }

    public void SpawnEnemies()
    {


        int spawnNum = Random.Range(0, spawnZones.Length);
        int enemyNum = Random.Range(0, enemyPrefabs.Length);

        GameObject EnemySpawn = Instantiate(EnemySpawnEffect, spawnZones[spawnNum].transform.position, Quaternion.identity);
        Destroy(EnemySpawn, 3);

        GameObject Enemy = Instantiate(enemyPrefabs[enemyNum], spawnZones[spawnNum].transform.position, Quaternion.identity, transform);
        Enemy.GetComponent<EnemyHealth>().MaxHealth += RoomManager.instance.CalculateEnemyHealthScaler();
        Enemy.GetComponent<EnemyHealth>().Health += RoomManager.instance.CalculateEnemyHealthScaler();
        Enemy.GetComponent<EnemyHealth>().XpGiven = RoomManager.instance.difficultyXp;
        Enemy.GetComponent<EnemyAiController>().roomspawn = this;
        Enemy.GetComponent<EnemyAiController>().IsRogueLite = true;
        enemyList.Add(Enemy);



    }

    
}
