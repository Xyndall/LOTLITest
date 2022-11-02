using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetBonusIcons : MonoBehaviour
{
    public SetBonuses _setBonus;

    public void OnCursorEnter()
    {
        if (_setBonus == null) return;

        //display item info
        GameManager.instance.DisplayItemInfo(_setBonus.name, _setBonus.GetItemDescription(), transform.position);
    }

    public void OnCursorExit()
    {
        if (_setBonus == null) return;

        GameManager.instance.DestroyItemInfo();
    }

}
