using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShopButton : MonoBehaviour
{
    public int ItemCost;
    
    public TextMeshProUGUI CostText;

    public ItemDrop item;
    public Image icon;

    

    void Start()
    {
        icon.sprite = item.icon;
    }


    void Update()
    {
        CostText.text = ItemCost.ToString();
    }

    public void BuyItem()
    {
        if(MoneyManager.Money >= ItemCost)
        {
            MoneyManager.Money -= ItemCost;
            item.Use();
            ItemCost = Mathf.RoundToInt(ItemCost + (ItemCost / 7));
            
        }
        else
        {
            Debug.Log("Cant Afford");
        }
        
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
}
