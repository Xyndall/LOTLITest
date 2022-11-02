using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeScript : MonoBehaviour
{
    public float Damage;

    public BoxCollider _collider;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log(other.gameObject);
            other.GetComponent<PlayerHealth>().TakeDamage(Damage);
        }
    }


    void TurnOnTrigger()
    {
        _collider.GetComponent<BoxCollider>().enabled = true;
        
    }
    void TurnOffTrigger()
    {
        _collider.GetComponent<BoxCollider>().enabled = false;
    }

}
