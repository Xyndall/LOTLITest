using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    float Damage;
    public int MaxDamage;
    public int MinDamage;

    public GameObject destroyedSpawn;

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Damage = Random.Range(MinDamage, MaxDamage);
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(Damage);
            Destroy(gameObject);
        }

        if (collision.gameObject.layer == 10 || collision.gameObject.layer == 14)
        {
            GameObject effect = Instantiate(destroyedSpawn, transform.position, Quaternion.identity);
            Destroy(effect, 1);
            Destroy(gameObject);
        }

    }



    private void Start()
    {
        Destroy(gameObject, 5);
    }

}
