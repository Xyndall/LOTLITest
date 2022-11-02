using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class StartTimelines : MonoBehaviour
{

    public PlayableDirector director;


    public void PauseTimeline()
    {
        director.GetComponent<PlayableDirector>().Pause();
    }

        public void StartTimeline()
        {
            director.GetComponent<PlayableDirector>().Play();
        }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartTimeline();
        }
    }

}
