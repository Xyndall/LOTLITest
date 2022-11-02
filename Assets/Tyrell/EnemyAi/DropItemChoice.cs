using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItemChoice : MonoBehaviour
{
    public List<ItemDrop> itemList = new List<ItemDrop>();
    public List<ItemDrop> NewitemList = new List<ItemDrop>();

    public DropItemChooser Items;

    public List<DropItemChooser> itemChoiceList = new List<DropItemChooser>();

    [SerializeField]
    int totalCount = 3;
    int completedCount = 0;


    private void Start()
    {
        //closes inventory when items show
        InventoryUIHandler.instance.CloseInventory();
    }

    private void Update()
    {

        itemChoiceList.RemoveAll(GameObject => GameObject == null);

    }

    public void EndOfWave()
    {
        for (int i = 0; i < totalCount; i++)
        {
            SpawnItems();
            completedCount += 1;
            if (completedCount == totalCount)
            {
                updateitemList();
            }
        }
    }

    public void ShowItems()
    {

        for (int i = 0; i < totalCount; i++)
        {
            SpawnItems();
            completedCount += 1;
            if (completedCount == totalCount)
            {
                updateitemList();
            }
        }

    }

    //should reset item list to new item list;
    void updateitemList()
    {
        completedCount = 0;
        itemList.Clear();
        itemList.AddRange(NewitemList);
    }


    //removes item from list so that it cannot be chosen again
    public void RemoveFromList(ItemDrop item)
    {
        itemList.Remove(item);
    }

    void SpawnItems()
    {
        DropItemChooser itemchooser = Instantiate(Items, this.transform.transform);
        itemChoiceList.Add(itemchooser);
        ItemDrop newitem = itemList[Random.Range(0, itemList.Count)];
        itemchooser.AddItem(newitem);
        itemchooser.itemChoice = this;
        //remove item from list so that it cannot be chosen again;
        RemoveFromList(newitem);
    }


    public void DestoryItems()
    {
        GameManager.instance.DestroyItemInfo();
        foreach (DropItemChooser items in itemChoiceList)
        {
            Destroy(items.gameObject);

        }


    }




}
