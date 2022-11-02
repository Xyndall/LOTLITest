using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemChooser : MonoBehaviour
{
    public ItemChoice itemChoice;

    public Item item;

    public Image image;

    public WaveGameManager manager;
    

    private void Start()
    {
        manager = FindObjectOfType<WaveGameManager>();
        image.GetComponent<Image>();

        
    }


    public void AddItem(Item newItem)
    {
        //Debug.Log("New Item");
        item = newItem;
        image.sprite = newItem.icon;
        
        
    }

    public void OnCursorEnter()
    {
        if (item == null) return;

        //display item info
        GameManager.instance.DisplayItemInfo(item.name, item.GetItemDescription(), transform.position);
    }

    public void OnCursorExit()
    {
        if (item == null) return;

        GameManager.instance.DestroyItemInfo();
    }

    public void PutInInventory()
    {
        Inventory.instance.AddItemToGun(Instantiate(item));
        
    }

    public void ClearItemChoice()
    {
        
        manager.GetComponent<WaveGameManager>();
        manager.DestroyItemChoice();
        
    }
    
    public void ClearItems()
    {

        ShowItems.instance.DestroyItemChoice();
    }
}
