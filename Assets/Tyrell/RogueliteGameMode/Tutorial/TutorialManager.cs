using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{

    #region singleton
    public static TutorialManager instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    #endregion

    public GameObject TutDeathMSG;

    public void TutorialComplete()
    {
        ES3.Save("TutorialComplete", 1);
        LoadSceneManager.instance.LoadStartingArea();

    }

    public void ShowDeathMSG()
    {
        StartCoroutine(DeathMSG());
    }

    IEnumerator DeathMSG()
    {
        TutDeathMSG.SetActive(true);

        yield return new WaitForSeconds(5);

        TutDeathMSG.SetActive(false);
    }


}
