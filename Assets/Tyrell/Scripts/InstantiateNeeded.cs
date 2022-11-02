using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateNeeded : MonoBehaviour
{
    [SerializeField]
    private GameObject Player;

    [SerializeField]
    private GameObject InventoryCanvas;

    [SerializeField]
    private GameObject EnemySpawner;

    [SerializeField]
    private GameObject Hud;

    [SerializeField]
    private GameObject Shop;

    [SerializeField]
    private GameObject NavMesh;

    [SerializeField]
    private GameObject SpawnZones;

    private void Start()
    {
        
        if (Player.scene.IsValid())
        {
            Instantiate(Player, Vector3.zero, Quaternion.identity);
        }
        else
        {
            
        }


        if (InventoryCanvas.scene.IsValid())
        {
            Instantiate(InventoryCanvas);
        }
        else
        {
            
        }

        if (EnemySpawner.scene.IsValid())
        {
            Instantiate(EnemySpawner);
        }
        else
        {
           
        }

        if (Hud.scene.IsValid())
        {
            Instantiate(Hud);
        }
        else
        {
            
        }

        if(Shop.scene.IsValid())
        {
            Instantiate(Shop);
        }
        else
        {
            
        }

        if(NavMesh.scene.IsValid())
        {
            Instantiate(NavMesh);
        }
        else
        {
            
        }

        if (SpawnZones.scene.IsValid())
        {
            Instantiate(SpawnZones);
        }
        else
        {
            
        }


    }



}
