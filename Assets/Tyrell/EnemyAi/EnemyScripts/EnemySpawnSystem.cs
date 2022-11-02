using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemySpawnSystem : MonoBehaviour
{
    [Header("Enemy Variables")]
    float SpawnDelay = .2f;
    public int SpawnedEnemies = 0;

    [SerializeField]
    private Transform[] spawnZones; // Array filled with spawn zones transform

    [SerializeField]
    private GameObject[] enemyPrefabs; // All available enemy prefabs stored here

    [SerializeField]
    private List<GameObject> enemyList = new List<GameObject>();

    [SerializeField]
    private GameObject[] ElitePrefabs;
    
    [SerializeField]
    private GameObject BossPrefabs;


    [SerializeField]
    private int maxEnemySpawn;

    public GameObject EnemySpawnEffect;

    public Transform EnemyParent;

    public bool showItems;

    public int WaveNumber;
    public int MaxWaves;
    public bool StartedWaves;
    public bool nextWave;
    public float NextWaveTimer = 10;
    public float resetTimer = 10;

    int EliteWave = 0;


    public WaveGameManager manager;

    [Header("Multipliers")]
    [Range(1f, 300f)]
    public float additionMultiplier;
    [Range(2f, 4f)]
    public float powerMultiplier = 20f;
    [Range(7f, 14f)]
    public float divisionMultiplier = 7f;


    private void Start()
    {
        StartedWaves = false;
        StartWave();

        //send Analytics When game starts
        //Analytics.instance.GameStartAnalytics();

        //find game manager
        manager = FindObjectOfType<WaveGameManager>();
        manager.GetComponent<WaveGameManager>();
    }

    private void Update()
    {
        manager.WavesCompleted = WaveNumber - 1;


        if(enemyList.Count == 0 && StartedWaves == true)
        {
            nextWave = true;
            showItems = true;
            StartCoroutine(SpawnEnemiesOverTime());
            
            StartedWaves = false;
        }

        enemyList.RemoveAll(GameObject => GameObject == null);
    }

    public void ShowItemChooser()
    {
        manager.ShowItemChoice();
    }

    

    void StartWave()
    {
        StartedWaves = true;
        WaveNumber = 1;
        maxEnemySpawn = 2;

        for(int i = 0; i < maxEnemySpawn; i++)
        {
            SpawnEnemies();
        }
        


    }

    /*******///enemy spawning code
    IEnumerator SpawnEnemiesOverTime()
    {
        bool elitesSpawned = false;
        bool bossSpawned = false;
        yield return new WaitForSeconds(NextWaveTimer);
        

        WaveNumber++;
        SpawnedEnemies = 0;
        maxEnemySpawn = maxEnemySpawn + WaveNumber;
        StartedWaves = true;
        nextWave = false;
        WaitForSeconds Wait = new WaitForSeconds(SpawnDelay);

        while (SpawnedEnemies < maxEnemySpawn)
        {
            SpawnEnemies();

            SpawnedEnemies++;

            if (WaveNumber % 5 == 0 && !elitesSpawned)
            {
                EliteWave++;
                for (int i = 0; i < EliteWave; i++)
                {
                    
                    SpawnElites();
                    SpawnedEnemies++;
                    elitesSpawned = true;

                }
                

            }
            if (WaveNumber % 10 == 0 && !bossSpawned)
            {
                SpawnBoss();
                SpawnedEnemies++;
                bossSpawned = true;
            }
            yield return Wait;
        }
        

    }



    private void SpawnEnemies()
    {


        int spawnNum = Random.Range(0, spawnZones.Length);
        int enemyNum = Random.Range(0, enemyPrefabs.Length);

        GameObject EnemySpawn = Instantiate(EnemySpawnEffect, spawnZones[spawnNum].transform.position, Quaternion.identity);
        Destroy(EnemySpawn, 3);

        GameObject Enemy = Instantiate(enemyPrefabs[enemyNum], spawnZones[spawnNum].transform.position, Quaternion.identity, EnemyParent);
        Enemy.GetComponent<EnemyHealth>().MaxHealth += CalculateEnemyHealthScaler();
        Enemy.GetComponent<EnemyHealth>().Health += CalculateEnemyHealthScaler();
        Enemy.GetComponent<EnemyHealth>().XpGiven = 5;
        enemyList.Add(Enemy);
        


    }

    public void SpawnElites()
    {
        int spawnNum = Random.Range(0, spawnZones.Length);
        int enemyNum = Random.Range(0, ElitePrefabs.Length);

        GameObject EnemySpawn = Instantiate(EnemySpawnEffect, spawnZones[spawnNum].transform.position, Quaternion.identity);
        Destroy(EnemySpawn, 3);

        GameObject Enemy = Instantiate(ElitePrefabs[enemyNum], spawnZones[spawnNum].transform.position, Quaternion.identity, EnemyParent);
        Enemy.GetComponent<EnemyHealth>().MaxHealth += CalculateEnemyHealthScaler();
        Enemy.GetComponent<EnemyHealth>().Health += CalculateEnemyHealthScaler();
        Enemy.GetComponent<EnemyHealth>().XpGiven = 20;
        enemyList.Add(Enemy);
    }

    public void SpawnBoss()
    {
        int spawnNum = Random.Range(0, spawnZones.Length);

        GameObject EnemySpawn = Instantiate(EnemySpawnEffect, spawnZones[spawnNum].transform.position, Quaternion.identity);
        Destroy(EnemySpawn, 3);

        GameObject Enemy = Instantiate(BossPrefabs, spawnZones[spawnNum].transform.position, Quaternion.identity, EnemyParent);
        Enemy.GetComponent<BossHealth>().MaxHealth += CalculateEnemyHealthScaler();
        Enemy.GetComponent<BossHealth>().Health += CalculateEnemyHealthScaler();
        Enemy.GetComponent<BossHealth>().XpGiven = 100;
        enemyList.Add(Enemy);
    }


    public int CalculateEnemyHealthScaler()
    {
        int solveForHealth = 0;
        for (int WaveCycle = 1; WaveCycle <= WaveNumber; WaveCycle++)
        {
            solveForHealth += (int)Mathf.Floor(WaveCycle + additionMultiplier * Mathf.Pow(powerMultiplier, WaveCycle / divisionMultiplier));
        }
        return solveForHealth / 4;
    }
}
