using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidPuddle : MonoBehaviour
{
    public float AcidDamage = 2;
    public float TickTime = 1;
    PlayerHealth health;
   void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            health = collider.gameObject.GetComponent<PlayerHealth>();
            StartCoroutine(TakeDamage());
        }
    }
    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            health = null;
        }
    }
    IEnumerator TakeDamage()
    {
        while (health != null)
        {
            health.TakeDamage(AcidDamage);
            yield return new WaitForSeconds(TickTime);
        }
    }
}
