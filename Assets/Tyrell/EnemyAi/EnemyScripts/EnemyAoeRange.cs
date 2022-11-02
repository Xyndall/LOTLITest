using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAoeRange : EnemyAiController
{
    public GameObject projectile;
    public int ProjectilesFired = 5;
    public float projectileSpread = -45f;


    public float projectilesSpeed;
    public bool isElite;



    public override void AttackPlayer()
    {


        Vector3 offsetPlayer = player.transform.position - transform.position;

        Vector3 dir = Vector3.Cross(offsetPlayer, Vector3.down);
        agent.SetDestination(transform.position + dir);

        //Make sure enemy doesn't move
        //agent.SetDestination(transform.position);

        transform.LookAt(player);

        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);


        if (!alreadyAttacked)
        {
            ///Attack code here
            for (int i = 0; i < ProjectilesFired; i++)
            {

                GameObject aoeProjectile = Instantiate(projectile, transform.position + Vector3.up, Quaternion.identity);
                Rigidbody rb = aoeProjectile.GetComponent<Rigidbody>();

                aoeProjectile.transform.LookAt(player);

                aoeProjectile.transform.Rotate(0, projectileSpread, 0);

                projectileSpread += 15f;


                rb.AddForce(aoeProjectile.transform.forward * projectilesSpeed, ForceMode.VelocityChange);

            }

            ///End of attack code

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }

    }



    public override void ChasePlayer()
    {
        agent.SetDestination(player.position);


    }

    public override void ResetAttack()
    {
        base.ResetAttack();
        projectileSpread = -30;
    }

}

