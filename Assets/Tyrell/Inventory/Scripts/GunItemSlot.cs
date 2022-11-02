using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunItemSlot : ItemSlot
{

    public Sprite EmptySprite;



    private void Update()
    {
        if (icon.sprite == null)
        {
            icon.GetComponent<Image>().sprite = EmptySprite;
        }
    }
}

