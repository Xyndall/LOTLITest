using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentalDangers : MonoBehaviour
{


    public float Damage = 1;
    public float radius = 1;

    private void Start()
    {
        InvokeRepeating("DamageOverTime", 0, 1);
    }

    void DamageOverTime()
    {

        Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider col in hitColliders)
        {
            if (col.gameObject.tag == "Enemy")
            {       

                col.GetComponent<EnemyHealth>().EnemyTakeDamage(Damage, false);

            }
            if (col.gameObject.tag == "Player")
            {
                col.GetComponent<PlayerHealth>().TakeDamage(Damage);
                
            }
        }

    }




    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, radius);
    }
}
