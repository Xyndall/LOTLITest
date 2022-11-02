using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemInfo : MonoBehaviour
{
    public TextMeshProUGUI itemName;
    public TextMeshProUGUI itemDescription;

    public void SetUp(string name, string description)
    {
        itemName.text = name;
        itemDescription.text = description;
    }
}
