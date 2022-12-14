using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    public Image icon;
    public Item item;
    public bool isBeingDraged = false;

    public Item Item => item;

    InventoryUIHandler UIHandler;

    private void Start()
    {
        UIHandler = FindObjectOfType<InventoryUIHandler>();
    }

    public void PlayClick()
    {
        UIHandler.GetComponent<InventoryUIHandler>().PlayClick();
    }

    public void AddItem(Item newItem)
    {
        item = newItem;
        icon.sprite = newItem.icon;
    }

    public void ClearSlot()
    {
        item = null;
        icon.sprite = null;
    }

    public void RemoveItem()
    {
        Inventory.instance.SwitchHotBarToInventory(item);
        GameManager.instance.DestroyItemInfo();
    }

    public void UseItem()
    {
        if (item == null || isBeingDraged == true) return;
        
        Inventory.instance.SwitchInventoryToHotBar(item);
        GameManager.instance.DestroyItemInfo();
        

        
    }

    public void DestroySlot()
    {
        Destroy(gameObject);
    }

    public void OnRemoveButtonClicked()
    {
        if (item != null)
        {
            Inventory.instance.RemoveItem(item);
        }
    }

    public virtual void OnCursorEnter()
    {
        if (item == null || isBeingDraged == true) return;

        //display item info
        GameManager.instance.DisplayItemInfo(item.name, item.GetItemDescription(), transform.position);
    }

    public virtual void OnCursorExit()
    {
        if (item == null) return;

        GameManager.instance.DestroyItemInfo();
    }
}
