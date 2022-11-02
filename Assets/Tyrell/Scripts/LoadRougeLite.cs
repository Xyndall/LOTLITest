using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadRougeLite : MonoBehaviour
{
    public GameObject Text;
    bool inTrigger;

    public GameObject chooseDifficulty;

    public static int Difficulty = 2;
    

    private void Start()
    {
        chooseDifficulty.SetActive(false);
    }

    private void Update()
    {
        if (inTrigger)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                chooseDifficulty.SetActive(true);
            }
        }
    }

    public void SetNormal()
    {
        Difficulty = 2;
        
        LoadSceneManager.instance.LoadRogueGame();
    }

    public void SetEasy()
    {
        Difficulty = 1;
        
        LoadSceneManager.instance.LoadRogueGame();
    }

    public void SetHard()
    {
        Difficulty = 3;
        LoadSceneManager.instance.LoadRogueGame();
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Text.SetActive(true);
            inTrigger = true;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Text.SetActive(false);
            chooseDifficulty.SetActive(false);
            inTrigger = false;
        }

    }
}
