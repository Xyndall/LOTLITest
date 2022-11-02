using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTrap : MonoBehaviour
{

    public float Damage;
    public float radius = 1;



    void StartFireTrap()
    {
        InvokeRepeating("DamageOverTime", 0, 1);
    }
    void EndFireTrap()
    {
        CancelInvoke();
    }


    void DamageOverTime()
    {

        Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius);
        
        foreach (Collider col in hitColliders)
        {
            
            if (col.CompareTag( "Player"))
            {
                col.GetComponent<PlayerHealth>().TakeDamage(Damage);

            }
            if (col.CompareTag("Enemy"))
            {
                col.GetComponent<EnemyHealth>().EnemyTakeDamage(Damage, false);
            }
        }

    }




    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, radius);
    }




}
