using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickOpenClose : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(true);
        StartCoroutine(SetActiveBack());


    }

    IEnumerator SetActiveBack()
    {
        gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
    }

}
