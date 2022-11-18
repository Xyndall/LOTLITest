using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyExploder : EnemyAiController
{
    public GameObject Explosion;

    public float explosiveArea = 5;
    public float explosionDamage = 20;

    float flashinTimer = .2f;
    float nextFlash;

    public bool playerInExplodeRange;
    public float explodeRange;

    public LayerMask WhatIsOtherEnemies;

    private void Update()
    {
        //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
        playerInExplodeRange = Physics.CheckSphere(transform.position, explodeRange, whatIsPlayer);

        //if any of theese are true it will set the enemies state
        if (!playerInSightRange && !playerInAttackRange) Wander();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInAttackRange && playerInSightRange && !isFrozen) AttackPlayer();
        if (playerInExplodeRange) PlayerInRangeExplodeEnemy();
        
        nextFlash += Time.deltaTime;

        if (playerInAttackRange && !isFrozen)
        {
            if(nextFlash > flashinTimer)
            {
                GetComponent<Renderer>().material.SetColor("_BaseColor", Color.white);
                GetComponent<Renderer>().material.SetColor("_1st_ShadeColor", Color.white);
                
                StartCoroutine(Flashing());
            }
            else
            {
                GetComponent<Renderer>().material.SetColor("_BaseColor", Color.red);
                GetComponent<Renderer>().material.SetColor("_1st_ShadeColor", Color.red);
            }
        }

    }

    public override void AttackPlayer()
    {
        agent.SetDestination(player.position);

        transform.LookAt(player);
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
        if (!alreadyAttacked)
        {
            ///Attack code here
            
            GetComponent<NavMeshAgent>().speed = 30;
            GetComponent<NavMeshAgent>().acceleration = 30;
            StartCoroutine(ExplodeEnemy());
            ///End of attack code

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);




        }
        
    }

    IEnumerator Flashing()
    {
        yield return new WaitForSeconds(.2f);
        nextFlash = 0;
    }

    IEnumerator ExplodeEnemy()
    { 
        
        yield return new WaitForSeconds(5);
        if (!playerInExplodeRange)
        {
            CheckForPlayer();

            DestroyEnemy();
        }
        
    }

    void PlayerInRangeExplodeEnemy()
    {

        CheckForPlayer();

        DestroyEnemy();
    }

    public void CheckForPlayer()
    {
        CinemachineShake.Instance.ShakeCamera(5f, 0.2f);

        GameObject explosion = Instantiate(Explosion, transform.position, Quaternion.identity);
        explosion.transform.localScale = new Vector3(explosiveArea, explosiveArea, explosiveArea);
        Destroy(explosion, 1.5f);

        Collider[] colliders = Physics.OverlapSphere(transform.position, explosiveArea);
        foreach (Collider collider in colliders)
        {
            if (collider.gameObject.tag == "Player")
            {
                
                collider.gameObject.GetComponent<PlayerHealth>().TakeDamage(explosionDamage);

                
            }

            if (collider.gameObject.tag == "Enemy")
            {
                
                
                collider.gameObject.GetComponent<EnemyHealth>().EnemyTakeDamage(explosionDamage * 100, true);
                
            }
        }
    }


    public override void DestroyEnemy()
    {
        if (IsRogueLite == true)
        {
            roomspawn.RemoveEnemy(Enemy);
        }


        Destroy(Enemy);
        
        //only for the roguelite mode to check if it is the roguelite mode and remove from the room list

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, explodeRange);
    }
}
