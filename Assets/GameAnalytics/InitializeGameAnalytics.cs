using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameAnalyticsSDK;

public class InitializeGameAnalytics : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameAnalytics.Initialize();
    }

    //different GA commands

    //*--Use this event to track when players start and finish levels in your game.
    //This event follows a 3 tier hierarchy structure (World, Level and Phase)
    //to indicate a player's path or place in the game.--*//

    //GameAnalytics.NewProgressionEvent(GA_Progression.GAProgressionStatus progressionStatus,
    //string progression01, string progression02, string progression03, int score)


    //*-- Use this to create a custom event to track whatever we want--*//

    //GameAnalytics.NewDesignEvent (string eventName, float eventValue);


    //Custom dimensions 
    //This seems like it might be usefull need to look into further
    //https://go.gameanalytics.com/game/209031/content/sdk?page=unity&step=11


}
