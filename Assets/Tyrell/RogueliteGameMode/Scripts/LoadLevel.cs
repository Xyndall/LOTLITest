using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadLevel : MonoBehaviour
{

    public Animator animator;

    public void LoadStartingArea()
    {
        StartCoroutine(LoadStartingAreaAnimation());
    }



    IEnumerator LoadStartingAreaAnimation()
    {
        animator.SetTrigger("Start");

        yield return new WaitForSeconds(1);

        if (PlayerData.TutorialCompleted == true)
            LoadSceneManager.instance.LoadStartingArea();
        else
            LoadSceneManager.instance.LoadTutorial();
    }


}
