using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeWeapon : MonoBehaviour
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

        }
    }

}
