using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    #region singleton
    public static RoomManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    #endregion

    public Transform[] RoomSpawn;

    [Header("Enemy health Multipliers")]
    [Range(1f, 300f)]
    public float additionMultiplier;
    [Range(2f, 4f)]
    public float powerMultiplier = 20f;
    [Range(7f, 14f)]
    public float divisionMultiplier = 7f;

    //room prefabs
    [Header("RoomPrefabs")]
    public List<GameObject> UpgradeRoomList = new List<GameObject>();
    public List<GameObject> ShopRoomList = new List<GameObject>();
    public List<GameObject> ChallengeRoomList = new List<GameObject>();
    public List<GameObject> HallWay = new List<GameObject>();
    public GameObject HallWayToBoss;

    int hallwayNum;
    public int RoomNumber = 0;


    //Sets Player position at start of game
    public Transform player;
    Vector3 pos;
    float playerYPos = 1;


    public GameObject BossRoom;
    public int BossRoomNumber;


    public int difficultyXp = 0;
    int BaseEnemySpawn = 5;
    public int ExtraEnemies = 0;
    public int EliteEnemies;


    private void Start()
    {
        SetDifficulty();

        player = GameObject.FindWithTag("Player").transform;

        RoomNumber = 0;
        
        pos = RoomSpawn[RoomNumber].transform.position;
        pos.y = playerYPos;

        player.transform.position = pos;

        SpawnUpgradeRoom();

        

    }

    public void SetDifficulty()
    {

        switch (LoadRougeLite.Difficulty)
        {
            case 1:

                additionMultiplier = 2;
                powerMultiplier = 4;
                divisionMultiplier = 7f;
                difficultyXp = 5;
                ExtraEnemies = -2;
                EliteEnemies = 0;
                break;

            case 2:

                additionMultiplier = 10;
                powerMultiplier = 4;
                divisionMultiplier = 7f;
                difficultyXp = 10;
                ExtraEnemies = 0;
                EliteEnemies = 0;
                break;


            case 3:

                additionMultiplier = 40;
                powerMultiplier = 4;
                divisionMultiplier = 7f;
                difficultyXp = 20;
                ExtraEnemies = 2;
                EliteEnemies = 1;
                break;

            default:

                additionMultiplier = 100;
                powerMultiplier = 4;
                divisionMultiplier = 7f;
                difficultyXp = 100;
                ExtraEnemies = 5;
                EliteEnemies = 2;
                break;
        }

    }


    public void SpawnHallWay()
    {
        hallwayNum++;
        
        if (RoomNumber <= BossRoomNumber)
        {
            if(hallwayNum % 3 == 0)
            {
                Instantiate(HallWay[0], RoomSpawn[RoomNumber].transform.position, Quaternion.identity);
            }
            else
            {
                int hall = Random.Range(0, HallWay.Count);
                Instantiate(HallWay[hall], RoomSpawn[RoomNumber].transform.position, Quaternion.identity);
                
            }
            
        }
        else
        {
            Instantiate(HallWayToBoss, RoomSpawn[RoomNumber].transform.position, Quaternion.identity);
            
        }
        RoomNumber++;
    }


    public void SpawnUpgradeRoom()
    {
        
            int spawnedRoom = Random.Range(0, UpgradeRoomList.Count);
            Instantiate(UpgradeRoomList[spawnedRoom], RoomSpawn[RoomNumber].transform.position, Quaternion.identity);
            RoomNumber++;
            ///will remove spawned room so that it wil not spawn again
            UpgradeRoomList.RemoveAt(spawnedRoom);
        
        
    }

    public void SpawnShopRoom()
    {

            int spawnedRoom = Random.Range(0, ShopRoomList.Count);
            Instantiate(ShopRoomList[spawnedRoom], RoomSpawn[RoomNumber].transform.position, Quaternion.identity);
            RoomNumber++;
            

    }


    public void SpawnChallengeRoom()
    {
        EliteEnemies++;
        int spawnedRoom = Random.Range(0, ChallengeRoomList.Count);
        Instantiate(ChallengeRoomList[spawnedRoom], RoomSpawn[RoomNumber].transform.position, Quaternion.identity);
        RoomNumber++;

        ChallengeRoomList.RemoveAt(spawnedRoom);
    }

    public void SpawnBossRoom()
    {

        pos = RoomSpawn[RoomNumber].transform.position;
        pos.y = playerYPos;

        player.transform.position = pos;

        Instantiate(BossRoom, RoomSpawn[RoomNumber].transform.position, Quaternion.identity);

    }

    public int CalculateEnemySpawns()
    {
        int EnemiesToSpawn = 0;

        EnemiesToSpawn = BaseEnemySpawn + ExtraEnemies + (RoomNumber / 2);

        return EnemiesToSpawn;
    }


    public int CalculateEnemyHealthScaler()
    {
            int solveForHealth = 0;
            for (int RoomCycle = 1; RoomCycle <= RoomNumber; RoomCycle++)
            {
                solveForHealth += (int)Mathf.Floor(RoomCycle + additionMultiplier * Mathf.Pow(powerMultiplier, RoomCycle / divisionMultiplier));
            }
            return solveForHealth / 4;
    }

}


public enum RoomType
{
    Upgrade,
    Shop,
    Challenge,
    Loot,



}