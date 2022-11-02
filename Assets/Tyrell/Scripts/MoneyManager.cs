using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    #region singleton
    public static MoneyManager instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    #endregion


    public static int Money = 0;

    private void Start()
    {
        Money = 0;
    }

    private void Update()
    {
        if(Money < 0)
        {
            Money = 0;
        }
    }

    public void GainMoney(int Amount)
    {
        Money += Amount;
    }


    //Enemies drop money

    int droppedMoneyAmount;
    public int maxAmount = 3;
    public int minAmount = 1;

    //called from enemy health script
    public void DropMoney()
    {
        droppedMoneyAmount = Random.Range(minAmount, maxAmount);
        GainMoney(droppedMoneyAmount);
    }

    //called from upgradables script
    public void IncreaseMoney(float amount)
    {

        maxAmount += (int)amount;
        minAmount += (int)amount;
    }

}
