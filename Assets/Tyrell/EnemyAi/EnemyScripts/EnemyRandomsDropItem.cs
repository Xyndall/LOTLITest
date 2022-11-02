using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRandomsDropItem : MonoBehaviour
{
    
    

    public GameObject RareItem;
    public GameObject UncommonItem;
    public GameObject CommonItem;


    //public void RandomlyDropItem()
    //{
    //    int RandomSpawnChance = Random.Range(0, Upgradeables.instance.dropchanceincrease);
    //    int ItemRarity = Random.Range(0, Upgradeables.instance.dropchanceincrease);
    //    Debug.Log("spawn Chance: " + RandomSpawnChance + "Item Rarity: " + ItemRarity);
    //    if (RandomSpawnChance <= Upgradeables.instance.ItemDropChance)
    //    {

    //        if (ItemRarity <= 50)
    //        {
    //            GameObject commonItem = Instantiate(CommonItem, transform.position, Quaternion.identity);
    //            Destroy(commonItem, 5);
    //        }
    //        else if (ItemRarity >= 60)
    //        {
    //            GameObject uncommonItem = Instantiate(UncommonItem, transform.position, Quaternion.identity);
    //            Destroy(uncommonItem, 5);
    //        }
    //        else
    //        {
    //            GameObject rareItem = Instantiate(RareItem, transform.position, Quaternion.identity);
    //            Destroy(rareItem, 5);
    //        }

    //    }

    //}



}
