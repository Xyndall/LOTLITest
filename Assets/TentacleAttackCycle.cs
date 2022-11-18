using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentacleAttackCycle : MonoBehaviour
{
    public float idleTime = 5;
    public int numberOfAttack = 3;
    public float minTime = 2;
    public float maxTime = 10;
    public float minSleep = 3;
    public float maxSleep = 12;
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        StartCoroutine(Cycle());
    }

    IEnumerator Cycle()
    {
        while (enabled)
        {

            yield return new WaitForSeconds(Random.Range(minSleep, maxSleep));
            anim.SetTrigger("Spawn");
            yield return new WaitForSeconds(idleTime);

            for (int i = numberOfAttack; i > 0; i--)
            {
                idleTime = Random.Range(minTime, maxTime);
                yield return new WaitForSeconds(idleTime);
                anim.SetTrigger("Attack");

            }
            anim.SetTrigger("Despawn");
        }

    }
}
