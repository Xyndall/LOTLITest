using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentacleHitBox : MonoBehaviour
{
    public float TentacleDamage = 5;
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            collider.gameObject.GetComponent<PlayerHealth>().TakeDamage(TentacleDamage);
        }
    }

}
