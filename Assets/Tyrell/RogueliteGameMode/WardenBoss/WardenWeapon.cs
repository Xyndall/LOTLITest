using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WardenWeapon : MonoBehaviour
{

    float Damage;
    public int MaxDamage;
    public int MinDamage;
    bool alreadyAttacked = false;

    public SphereCollider SphereCollider;

    private void Start()
    {
        StartCoroutine(TurnOffCollider());
    }
    IEnumerator TurnOffCollider()
    {
        yield return new WaitForSeconds(.1f);
        SphereCollider.GetComponent<SphereCollider>().enabled = false;
        alreadyAttacked = false ;
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player" && !alreadyAttacked)
        {
            alreadyAttacked = true;
            Damage = Random.Range(MinDamage, MaxDamage);
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(Damage);

        }
    }
}
