using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveBarge : MonoBehaviour
{
    public Transform Destination;

    public EnemyBargeSpawn bargeSpawn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == ("Player") && bargeSpawn.enemyList.Count <= 0)
        {
            other.transform.position = Destination.position;
            Debug.Log("I LIIIIIVE");
        }
    }
}
