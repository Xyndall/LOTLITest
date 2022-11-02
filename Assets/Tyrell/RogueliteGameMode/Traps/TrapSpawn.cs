using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapSpawn : MonoBehaviour
{

    public GameObject[] Traps;
    public Transform[] trapsSpawn;

    // Start is called before the first frame update
    void Start()
    {
        foreach(Transform spawn in trapsSpawn)
        {
            int trap = Random.Range(0, Traps.Length);
            Instantiate(Traps[trap], spawn.position, Quaternion.identity, transform);
            

        }

    }


}
