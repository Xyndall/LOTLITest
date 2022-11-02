using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoss : EnemyAiController
{
    public GameObject projectile;
    public Animator animator;
    public Collider MeleeWeaponCollider;

    public override void AttackPlayer()
    {
        //MeleeWeaponCollider.enabled = true;
        agent.SetDestination(transform.position);

        transform.LookAt(player);
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
        if (!alreadyAttacked)
        {
            ///Attack code here
            animator.SetTrigger("isAttacking");


            ///End of attack code

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);




        }
    }

    public override void ResetAttack()
    {
        alreadyAttacked = false;
        //MeleeWeaponCollider.enabled = false;
    }
}
