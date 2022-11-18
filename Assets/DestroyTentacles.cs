using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTentacles : MonoBehaviour
{
    public GameObject[] tentacle;
    private void OnDestroy()
    {
        for(int i=0; i < tentacle.Length; i++)
        {
            if (tentacle[i]!=null)
                Destroy(tentacle[i]);
        }
    }
}
