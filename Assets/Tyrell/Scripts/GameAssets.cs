using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAssets : MonoBehaviour
{
    #region singleton
    public static GameAssets instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    #endregion


    public Transform pfDamagePopUp;
    

}
