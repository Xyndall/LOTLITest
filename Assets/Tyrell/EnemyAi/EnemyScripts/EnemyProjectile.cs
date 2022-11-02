using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    float Damage;
    public int MaxDamage;
    public int MinDamage;

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Damage = Random.Range(MinDamage, MaxDamage);
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(Damage);
            Destroy(gameObject);
            
        }

        
    }



    private void Start()
    {
        Destroy(gameObject, 5);
    }

}
