using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{ 
    #region singleton

public static Inventory instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    #endregion

    public delegate void OnItemChange();
    public OnItemChange onItemChange = delegate { };

    public List<Item> inventoryItemList = new List<Item>();

    public List<Item> GunInventoryItemList = new List<Item>();
    public GunInventoryController gunInventoryController;

    

    void Start()
    {

         gunInventoryController = FindObjectOfType<GunInventoryController>(transform);

    }

    public void SwitchInventoryToHotBar(Item item)
    {


        //inventory to hotbar, CHECK if we have enaugh space
        foreach (Item i in inventoryItemList)
        {
            if (i == item)
            {
                if (GunInventoryItemList.Count >= gunInventoryController.GunInventorySlotSize)
                {
                    Debug.Log("No more slots available in guninventory");
                }
                else
                {
                    GunInventoryItemList.Add(item);
                    inventoryItemList.Remove(item);
                    item.Use();
                    onItemChange.Invoke();
                }
                return;
            }
        }

        //hotbar to inventory
        foreach (Item i in GunInventoryItemList)
        {
            if (i == item)
            {
                GunInventoryItemList.Remove(item);
                inventoryItemList.Add(item);
                item.Remove();
                onItemChange.Invoke();
                return;
            }
        }

    }

    public void SwitchHotBarToInventory(Item item)
    {
        //hotbar to inventory
        foreach (Item i in GunInventoryItemList)
        {
            if (i == item)
            {
                GunInventoryItemList.Remove(item);
                inventoryItemList.Add(item);
                item.Remove();
                onItemChange.Invoke();
                return;
            }
        }
    }

    public void AddItem(Item item)
    {
        inventoryItemList.Add(item);
        onItemChange.Invoke();
    }

    public void AddItemToGun(Item item)
    {
        
        if (GunInventoryItemList.Count >= gunInventoryController.GunInventorySlotSize)
        {
            AddItem(item);
        }
        else
        {
            GunInventoryItemList.Add(item);
            item.Use();
            onItemChange.Invoke();
            
        }
        
    }


    public void RemoveItem(Item item)
    {
        if (inventoryItemList.Contains(item))
        {
            inventoryItemList.Remove(item);
        }
        else if (GunInventoryItemList.Contains(item))
        {
            GunInventoryItemList.Remove(item);
        }

        onItemChange.Invoke();
    }

    public bool ContainsItem(string itemName, int amount)
    {
        int itemCounter = 0;

        foreach (Item i in inventoryItemList)
        {
            if (i.name == itemName)
            {
                itemCounter++;
            }
        }

        foreach (Item i in GunInventoryItemList)
        {
            if (i.name == itemName)
            {
                itemCounter++;
            }
        }

        if (itemCounter >= amount)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void RemoveItems(string itemName, int amount)
    {
        for (int i = 0; i < amount; ++i)
        {
            RemoveItemType(itemName);
        }
    }

    public void RemoveItemType(string itemName)
    {
        foreach (Item i in inventoryItemList)
        {
            if (i.name == itemName)
            {
                inventoryItemList.Remove(i);
                return;
            }
        }

        foreach (Item i in GunInventoryItemList)
        {
            if (i.name == itemName)
            {
                GunInventoryItemList.Remove(i);
                return;
            }
        }
    }

}
