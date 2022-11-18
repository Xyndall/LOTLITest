using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeToDestroy : MonoBehaviour
{
    public float DespawnTime = 15;
    void Start()
    {
        Destroy(gameObject,DespawnTime);
    }
}
