using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MeleeEnemy : EnemyAiController
{
    
    public Animator animator;

    [SerializeField]
    private Transform agentTransform;

    private float zigZagDelta = 2;

    private float zigZagDistance = 30;

    private void Start()
    {
        //this will find the player transform when the enemy is spawned ///very important
        if (GameObject.FindWithTag("Player") != null)
        {
            player = GameObject.FindWithTag("Player").transform;
        }
        zigZagDelta = Random.Range(10, 20);
        zigZagDistance = Random.Range(10, 40);

        StartCoroutine(WaitBeforeAttack());
    }

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

    

    Vector3 ZigZagStrafe()
    {
        

        // using sinus to generate zigzag between -1 and 1 , multiplying with some magnitude
        float t = Mathf.Sin(zigZagDelta) * zigZagDistance;

        // this is in local space
        Vector3 zigZagDisplacementLocal;
        if (zigZagDistance >= 25)
        {
            
            zigZagDisplacementLocal = Vector3.right * t;
        }
        else
        {
            
            zigZagDisplacementLocal = Vector3.left * t;
        }
        
        // this is now in world space
        Vector3 zigZagDisplacementWorld = agentTransform.TransformDirection(zigZagDisplacementLocal);

        return zigZagDisplacementWorld;
    }

    public override void ChasePlayer()
    {
        zigZagDelta += Time.deltaTime;

        Vector3 movementPos = player.position;
        //movementPos += ZigZagStrafe(); // add the offset from the zigzag
        //transform.LookAt(player);
        //transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
        agent.SetDestination(movementPos);
    }


    public override void ResetAttack()
    {
        alreadyAttacked=false;
        //MeleeWeaponCollider.enabled = false;
    }


}
