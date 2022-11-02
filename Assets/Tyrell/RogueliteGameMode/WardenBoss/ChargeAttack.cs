using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeAttack : MonoBehaviour
{

    public float ChargeDamage = 20;
    public float ChargeForce = 100;


    bool alreadyAttacked = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !alreadyAttacked)
        {
            alreadyAttacked = true;

            Debug.Log("warden charge hit");
            other.gameObject.GetComponent<PlayerHealth>().TakeDamage(ChargeDamage);
            other.gameObject.GetComponent<movement>().Knockback(transform.forward);
            StartCoroutine(ResetAttack());

        }
    }

    IEnumerator ResetAttack()
    {
        yield return new WaitForSeconds(2);
        alreadyAttacked = false ;
    }
}
