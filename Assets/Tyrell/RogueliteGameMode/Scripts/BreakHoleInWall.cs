using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakHoleInWall : MonoBehaviour
{

    public Mesh _NormalWall;
    public Mesh _WallHole;

    public GameObject _wallBreakParticles;
    public Transform _particleSpawn;

    bool alreadyBroken = false;

    public EnemyRoomSpawn roomspawn;

    private void Start()
    {
        GetComponent<MeshFilter>().mesh = _NormalWall;

        roomspawn = GameObject.FindWithTag("RoomSpawn").GetComponent<EnemyRoomSpawn>();

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerBullet"))
        {
            Debug.Log(alreadyBroken);
            Debug.Log(roomspawn.enemyList.Count);   
        }

        if (other.CompareTag("PlayerBullet") && !alreadyBroken && roomspawn.enemyList.Count <= 0)
        {
            Debug.Log("Broke Wall");
            alreadyBroken = true;
            GetComponent<MeshFilter>().mesh = _WallHole;
            gameObject.AddComponent<TeleportToHallWay>();

            GameObject wallbreak = Instantiate(_wallBreakParticles, _particleSpawn.position, transform.localRotation);
            Destroy(wallbreak, 4f);
        }


    }

}
