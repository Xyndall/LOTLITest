using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : EnemyAiController
{
    public GameObject projectile;

    public float bulletVelocity = 0f;

    public AudioClip aClip;
    public override void AttackPlayer()
    {
        Vector3 offsetPlayer = player.transform.position - transform.position;
        Vector3 dir = Vector3.Cross(offsetPlayer, Vector3.up);
        agent.SetDestination(transform.position + dir);

        transform.LookAt(player);
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
        if (!alreadyAttacked)
        {
            aSource.PlayOneShot(aClip);

            ///Attack code here
            Rigidbody rb = Instantiate(projectile, transform.position + Vector3.up, Quaternion.identity).GetComponent<Rigidbody>();
            rb.transform.LookAt(player.transform);
            rb.velocity = transform.forward * bulletVelocity;
            //rb.AddForce(transform.up * 8f, ForceMode.Impulse);

            ///End of attack code

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
        
    }

}
