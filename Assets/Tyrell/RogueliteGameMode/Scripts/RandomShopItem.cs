using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RandomShopItem : MonoBehaviour
{
    public GameObject shopItem;
    public Transform[] ShopItemSpawn;

    public List<ItemDrop> ChoseItemList = new List<ItemDrop>();
    int totalCount = 3;
    int shopSpawn = 0;

    public GameObject PopUpBuyText;

    public RandomShopItem thisScript;

    void Start()
    {
        
        HideBuyText();
        for (int i = 0; i < totalCount; i++)
        {
            SpawnItems();
                
                
        }
    }

    public void SpawnItems()
    {
        ItemDrop newItem = ChoseItemList[Random.Range(0, ChoseItemList.Count)];
        
        GameObject _shopItem = Instantiate(shopItem, ShopItemSpawn[shopSpawn].transform.position, Quaternion.Euler(0,-90,0), transform);

        shopSpawn++;
        _shopItem.GetComponent<ShopItem>().ChoseItem = this;
        
        _shopItem.GetComponent<ShopItem>().item = newItem;
        

        RemoveFromList(newItem);
        
    }

    public void RemoveFromList(ItemDrop item)
    {
        ChoseItemList.Remove(item);
    }


    public void ShowBuyText()
    {
        PopUpBuyText.SetActive(true);
    }

    public void HideBuyText()
    {
        PopUpBuyText.SetActive(false);
    }
}
