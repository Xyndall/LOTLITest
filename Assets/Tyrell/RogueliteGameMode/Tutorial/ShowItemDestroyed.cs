using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowItemDestroyed : MonoBehaviour
{

    public ShowItems itemShow;
    public StartTimelines timelineStart;

    bool itemShown = false;

    private void Update()
    {
        if (itemShow.GetComponent<ShowItems>().ItemChoiceDestryoed && !itemShown)
        {
            timelineStart.StartTimeline();
            itemShown = true;
        }
    }

}
