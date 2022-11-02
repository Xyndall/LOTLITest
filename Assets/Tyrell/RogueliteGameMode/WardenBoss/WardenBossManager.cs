using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class WardenBossManager : MonoBehaviour
{
    [Header("Phase Two Change")]
    public bool PhaseTwo;
    public GameObject _switch;
    public int boilerDestroyed = 0;
    public Transform Player;
    public Transform playerNewPos;
    public GameObject[] CloseWalls;
    public GameObject WardenBoss;
    public GameObject IdleBoss;
    public Transform WardenBossSpawn;
    public GameObject Laser;


    //*************** Enemy Spawn variables
    [Header("Enemy Variables")]
    float SpawnDelay = 5;
    public int SpawnedEnemies = 0;
    int NumberOfEnemiesToSpawn = 100;
    int EnemyHealthAdd = 0;
    public GameObject[] enemyPrefabs;
    public Transform[] spawnZones;
    public List<GameObject> enemyList = new List<GameObject>();
    public GameObject EnemySpawnEffect;
    //****************



    private void Start()
    {
        StartCoroutine(SpawnEnemiesOverTime());
        PhaseTwo = false;
        Laser.SetActive(true);
        _switch.SetActive(true);
        Player = GameObject.FindWithTag("Player").GetComponent<Transform>();
        foreach (GameObject wall in CloseWalls)
        {
            wall.SetActive(false);
        }
    }

    private void Update()
    {

        // enemy spawning
        enemyList.RemoveAll(GameObject => GameObject == null);

        if (enemyList.Count <= 0)
        {
            SpawnedEnemies = 0;
        }
        //enemy Spawning

        if(_switch.GetComponent<Switch>().leverSwitched &&
            boilerDestroyed >= 2 && !PhaseTwo)
        {
            PhaseTwo = true;
            BossPhaseTwo();
        }

        

    }



    void BossPhaseTwo()
    {
        Laser.SetActive(false);
        _switch.SetActive(false);
        Player.position = playerNewPos.position;
        foreach(GameObject wall in CloseWalls)
        {
            wall.SetActive(true);
        }
        Instantiate(WardenBoss, WardenBossSpawn.position, Quaternion.identity);
        Destroy(IdleBoss);
    }


    /*******///enemy spawning code
    IEnumerator SpawnEnemiesOverTime()
    {

        SpawnedEnemies = 0;

        WaitForSeconds Wait = new WaitForSeconds(SpawnDelay);

        while (SpawnedEnemies < NumberOfEnemiesToSpawn)
        {
            if (PhaseTwo)
            {
                foreach (GameObject enemy in enemyList)
                {
                    Destroy(enemy);
                }
                break;

            }

            SpawnRandomEnemy();

            SpawnedEnemies++;

            EnemyHealthAdd += 5;

            if (!PhaseTwo)
            {
                yield return Wait;
            }
            

        }
        
    }

    void SpawnRandomEnemy()
    {
        int spawnNum = Random.Range(0, spawnZones.Length);
        int enemyNum = Random.Range(0, enemyPrefabs.Length);

        GameObject EnemySpawn = Instantiate(EnemySpawnEffect, spawnZones[spawnNum].transform.position, Quaternion.identity);
        Destroy(EnemySpawn, 3);

        GameObject Enemy = Instantiate(enemyPrefabs[enemyNum], spawnZones[spawnNum].transform.position, Quaternion.identity, transform);
        // need a health scaler the scales over time maybe??
        Enemy.GetComponent<EnemyHealth>().MaxHealth += EnemyHealthAdd;
        Enemy.GetComponent<EnemyHealth>().Health += EnemyHealthAdd;
        enemyList.Add(Enemy);
    }

}
