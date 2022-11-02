using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAOERangedGuardVer : EnemyAiController
{

    public GameObject projectile;
    public int ProjectilesFired = 5;
    public float projectileSpread = -45f;

    public Animator animator;

    public float projectilesSpeed;
    public bool isElite;

    public Transform GunPoint;
    public GameObject MuzzleFlash;

    public override void AttackPlayer()
    {
        agent.SetDestination(transform.position);

        //Make sure enemy doesn't move
        //agent.SetDestination(transform.position);

        transform.LookAt(player);

        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);


        if (!alreadyAttacked)
        {
            ///Attack code here
            for (int i = 0; i < ProjectilesFired; i++)
            {
                animator.SetTrigger("isAttacking");

                GameObject muzFlash = Instantiate(MuzzleFlash, GunPoint.position, Quaternion.identity);
                muzFlash.transform.LookAt(player);
                muzFlash.transform.Rotate(0, -90, 0);
                Destroy(muzFlash, 0.05f);

                GameObject aoeProjectile = Instantiate(projectile, new Vector3(GunPoint.position.x, 2, GunPoint.position.z) , Quaternion.identity);

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
