using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowPierceUpgrades : MonoBehaviour
{

    public ShowItems showItems;

    int shownTimes = 0;



    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (showItems.GetComponent<ShowItems>().ItemChoiceDestryoed && shownTimes <= 0)
            {
                shownTimes++;
                showItems.GetComponent<ShowItems>().ShowItemChoice();
            }
        }

    }


}
