using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropItemChooser : MonoBehaviour
{
    public DropItemChoice itemChoice;

    public ItemDrop item;

    public Image image;


    private void Start()
    {
        image.GetComponent<Image>();
    }


    public void AddItem(ItemDrop newItem)
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

    public void Use()
    {
        item.Use();

    }

    public void ClearItems()
    {
        itemChoice.DestoryItems();
        itemChoice.gameObject.SetActive(false);
    }
}
