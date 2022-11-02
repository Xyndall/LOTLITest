using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserRotate : MonoBehaviour
{
    float Damage = 5;

    // Update is called once per frame
    void Update()
    {

        transform.Rotate(0, 10 * Time.deltaTime, 0);

    }

    private void OnTriggerEnter(Collider other)
    {
        

        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Laser hit enemy");
            other.gameObject.GetComponent<EnemyHealth>().EnemyTakeDamage(Damage, false);
        }

        if (other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerHealth>().TakeDamage(Damage);
        }

    }
}
