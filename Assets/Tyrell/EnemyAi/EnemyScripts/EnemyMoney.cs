using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoney : MonoBehaviour
{
    int droppedMoneyAmount;
    public int maxAmount;
    public int minAmount;

    public void DropMoney()
    {
        droppedMoneyAmount = Random.Range(minAmount,maxAmount);
        MoneyManager.instance.GainMoney(droppedMoneyAmount);
    }


    //called from upgradables script
    public  void IncreaseMoney(float amount)
    {
        
        maxAmount = maxAmount + (int)amount;
        minAmount = minAmount + (int)amount;
    }


}
