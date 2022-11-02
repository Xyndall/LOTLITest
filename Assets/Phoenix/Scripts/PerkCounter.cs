using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PerkCounter : MonoBehaviour
{
    #region Waffles
    public static PerkCounter instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion
    //Script
    public PlayerItemUpgradeRemove playerPerk;
    //Text
    public TextMeshProUGUI perkIncrease;
    //Perk
    int perks;

    private void Start()
    {
        perkIncrease.text = perks.ToString();
    }

    public void AddScore()
    {
        //When Player gets a perk the counter increases by one
        perks += 1;
        perkIncrease.text = perks.ToString();
    }
}
