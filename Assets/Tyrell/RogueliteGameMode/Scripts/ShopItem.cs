using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{

    public int ItemCost;

    public TextMeshProUGUI CostText;
    public TextMeshProUGUI ItemNameText;

    public ItemDrop item;
    public RandomShopItem ChoseItem;

    bool playerInTrigger = false;

    public List<Mesh> foodMeshes = new List<Mesh>();

    private void Start()
    {
        if(FindObjectOfType<RandomShopItem>() != null)
        {
            ChoseItem = FindObjectOfType<RandomShopItem>();
        }

        ItemCost = item.ItemCost;

        CostText.text = ItemCost + "";
        ItemNameText.text = item.name;
        int randomfood = Random.Range(0, foodMeshes.Count);
        GetComponent<MeshFilter>().mesh = foodMeshes[randomfood]; 
    }


    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            ChoseItem.ShowBuyText();
            playerInTrigger = true;   
        }

        
    }


    private void Update()
    {
        if (playerInTrigger & Input.GetKeyDown(KeyCode.E))
        {
            BuyItem();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            ChoseItem.HideBuyText();
            playerInTrigger = false;
        }
    }

    public void BuyItem()
    {
        if (MoneyManager.Money >= ItemCost)
        {
            MoneyManager.Money -= ItemCost;
            item.Use();
            ChoseItem.HideBuyText();
            Destroy(this.gameObject);

        }
        else
        {
            Debug.Log("Cant Afford");
        }

    }
}
