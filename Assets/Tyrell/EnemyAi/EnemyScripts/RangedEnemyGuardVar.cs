using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemyGuardVar : EnemyAiController
{


    public Animator animator;

    public GameObject projectile;

    public float bulletVelocity = 0f;
    public Transform GunPoint;
    public GameObject MuzzleFlash;

    public override void AttackPlayer()
    {
        
        agent.SetDestination(transform.position);

        transform.LookAt(player);
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
        if (!alreadyAttacked)
        {
            ///Attack code here
            
            animator.SetTrigger("isAttacking");

            GameObject muzFlash = Instantiate(MuzzleFlash, GunPoint.position, Quaternion.identity);
            muzFlash.transform.LookAt(player);
            muzFlash.transform.Rotate(0, -90, 0);
            Destroy(muzFlash, 0.05f);

            Rigidbody rb = Instantiate(projectile, new Vector3(GunPoint.position.x, 2, GunPoint.position.z), Quaternion.identity).GetComponent<Rigidbody>();
            rb.gameObject.transform.LookAt(player.transform);
            rb.velocity = transform.forward * bulletVelocity;
            rb.gameObject.transform.Rotate(0, -90, 0);
            //rb.AddForce(transform.up * 8f, ForceMode.Impulse);

            ///End of attack code

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }

    }
}
