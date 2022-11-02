using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathParticle : MonoBehaviour
{
    public GameObject pSystem;

    public Color newColor;


    // Start is called before the first frame update
    void Start()
    {
        pSystem.GetComponent<Renderer>().material.SetColor("_BaseColor", newColor);

    }

}
