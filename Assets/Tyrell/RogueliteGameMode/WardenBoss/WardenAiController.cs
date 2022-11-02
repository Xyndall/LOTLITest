using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class WardenAiController : MonoBehaviour
{
    //nav mesh agent that should be on the enemy
    public NavMeshAgent agent;

    //players transform so enemy knows what to look for
    public Transform player;


    //layermask so the ai knows what is the ground and player
    public LayerMask whatIsGround, whatIsPlayer;

    //Patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking
    public float timeBetweenAttacks;
    public bool alreadyAttacked;

    //States
    public float sightRange, attackRange, ChargeRange;
    public bool playerInSightRange, playerInAttackRange, playerInChargeRange;

    bool ChargeReady = false;
    float TimeToCharge = 15;
    float NextCharge;
    
    public GameObject ChargeCollider;

    //AnimationPlayer
    public Animator _animator;


    public GameObject GroundBreak;
    public GameObject particleFart;
    public Transform Weapon;

    //sets the animation states
    public bool AnimationStarted = false;
    public bool AnimationFinished = true;
    Vector3 Lastpos;
    public Transform Root;

    void Awake()
    {

        agent = GetComponent<NavMeshAgent>();
    }


    private void Start()
    {
        //this will find the player transform when the enemy is spawned ///very important
        if (GameObject.FindWithTag("Player") != null)
        {
            player = GameObject.FindWithTag("Player").transform;
        }
        InvokeRepeating("TriggerFart", 5, 10);

    }

    public void GroundBreakSpawn()
    {
        GameObject particle = Instantiate(GroundBreak, Weapon.position, Quaternion.Euler(-90, 0, 0));
        Destroy(particle, 4);
    }

    void TriggerFart()
    {
        _animator.SetTrigger("canFart");
    }

    public void Fart()
    {
        GameObject particle = Instantiate(particleFart, transform.position, Quaternion.Euler(90, 0, 0));
        Destroy(particle, 10);
    }


    private void Update()
    {
        
        //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
        playerInChargeRange = Physics.CheckSphere(transform.position, ChargeRange, whatIsPlayer);


        //if any of theese are true it will set the enemies state
        if (!playerInSightRange && !playerInAttackRange) Patroling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInAttackRange && playerInSightRange) WeaponSlam();
        if (playerInChargeRange && ChargeReady) ChargeAttack();

        if(ChargeReady == false)
        {
            if (Time.time > NextCharge && TimeToCharge > 0)
            {
                NextCharge = Time.time + TimeToCharge;
                ChargeReady = true;
            }
        }

        if (alreadyAttacked)
        {
            BossPause();
        }

        
    }

    void BossPause()
    {
        gameObject.GetComponent<NavMeshAgent>().isStopped = true;
    }

    void Patroling()
    {
        //will search for a walk point in an area set in the inspectors walk point range
        if (!walkPointSet) SearchWalkPoint();

        //will set the destination that the enemy will go to
        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }

    void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }


    //will chase the player if in sight range
    void ChasePlayer()
    {
        if (!alreadyAttacked)
        {
            _animator.SetBool("isWalking", true);
            transform.LookAt(player);
        }
        agent.SetDestination(player.position);

    }
    

    void ChargeAttack()
    {
        
         transform.LookAt(player);
         _animator.SetTrigger("ChargeAttack");
        ChargeReady = false;
    }

    IEnumerator IsChargingFalsed()
    {
        yield return new WaitForSeconds(2);
        ChargeCollider.SetActive(false);
    }
    void IsChargingTrue()
    {
        
        ChargeCollider.SetActive(true);
    }

    void GetPosition()
    {
        Lastpos = Root.position;
        Invoke("SetPosition", 0.01f);
    }

    void SetPosition()
    {
        transform.position = Lastpos;
        
    }

    

    void WeaponSlam()
    {
        agent.SetDestination(transform.position);
        
        if (!alreadyAttacked)
        {
            
                ///Attack code here
                transform.LookAt(player);
            transform.Rotate(0, -15, 0);
                _animator.SetTrigger("isAttacking");


                ///End of attack code

                alreadyAttacked = true;
                Invoke(nameof(ResetAttack), timeBetweenAttacks);



        }

    }

    //resets the attack when called
    void ResetAttack()
    {
        alreadyAttacked = false;
        gameObject.GetComponent<NavMeshAgent>().isStopped = false;

    }

 

    //draws gizmos that you can see in the scene view when selecting the enemy
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, ChargeRange);
    }

}
