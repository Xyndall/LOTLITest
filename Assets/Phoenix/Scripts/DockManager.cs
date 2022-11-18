using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DockManager : MonoBehaviour
{
    #region
    public static DockManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    #endregion

    public Transform[] spawnZones; // Array filled with spawn zones transform

    public GameObject[] enemyPrefabs; // All available enemy prefabs stored here

    public List<GameObject> enemyList = new List<GameObject>();

    int BaseEnemySpawn = 5;
    public int ExtraEnemies = 0;
    public int maxEnemySpawn;

    public virtual void FixedUpdate()
    {
        enemyList.RemoveAll(GameObject => GameObject == null);
    }

    public int CalculateEnemySpawns()
    {
        int EnemiesToSpawn = 0;

        EnemiesToSpawn = BaseEnemySpawn + ExtraEnemies;

        return EnemiesToSpawn;
    }
}
