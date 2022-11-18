using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAiController : MonoBehaviour
{
    #region Variables
    //nav mesh agent that should be on the enemy
    public NavMeshAgent agent;

    //players transform so enemy knows what to look for
    public Transform player;   

    //layermask so the ai knows what is the ground and player
    public LayerMask whatIsGround, whatIsPlayer, whatIsntPlayer, whatIsBullet;

    //Attacking
    public float timeBetweenAttacks;
    public bool alreadyAttacked;

    
    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;
    public bool isFrozen = false;

    public GameObject Enemy;

    public Renderer[] RendMaterials;

    //Evade bullet
    bool bulletInRange;

    //Script for the roguelite mode enemy room spawn
    public EnemyRoomSpawn roomspawn;
    public EnemyBargeSpawn bargespawn;
    public bool IsRogueLite = false;

    public GameObject FreezePaticles;
    #endregion

    public AudioSource aSource;

    void Awake()
    {
        
        agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        aSource = GetComponent<AudioSource>();
        //this will find the player transform when the enemy is spawned ///very important
        if (GameObject.FindWithTag("Player") != null)
        {
            player = GameObject.FindWithTag("Player").transform;
        }
        StartCoroutine(WaitBeforeAttack());
        
    }


    private void Update()
    {
        //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
        bulletInRange = Physics.CheckSphere(transform.position, attackRange, whatIsBullet);

        //if any of theese are true it will set the enemies state
        if (!playerInSightRange && !playerInAttackRange) Wander();

        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        else if (playerInSightRange && playerInAttackRange && CanSeeTarget() == false) ChasePlayer();

        if (playerInAttackRange && playerInSightRange && !isFrozen && CanSeeTarget()) AttackPlayer();
        //if (!playerInAttackRange && playerInSightRange && bulletInRange) EvadeBullet();

        

    }

    public void IncreaseSightRange()
    {
        sightRange = 300;
    }

    bool CanSeeTarget()
    {
        RaycastHit raycastInfo;
        //calculate a ray to the target from the agent
        Vector3 rayToTarget = player.transform.position - this.transform.position;
        //perform a raycast to determine if there's anything between the agent and the target
        
        if (Physics.Raycast(this.transform.position, rayToTarget, out raycastInfo, sightRange))
        {
            //ray will hit the target if no other colliders in the way
            if (raycastInfo.transform.gameObject.tag == "Player")
                return true;
        }
        return false;
    }


    public void EvadeBullet()
    {

        //Vector3 Dodgepos;

        //int rand = Random.Range(0, 1);

        
        //if(rand == 1)
        //    Dodgepos = Vector3.right;
        //else
        //    Dodgepos = Vector3.left;

        //transform.LookAt(player);
        //agent.Move(Dodgepos * 5 * Time.deltaTime);
        

    }

    ///freeze
    public void StartFrozen(float freezeTime)
    {
        StartCoroutine(SetFrozen(freezeTime));
    }

    IEnumerator SetFrozen(float FreezeTime)
    {
        GameObject freeze = Instantiate(FreezePaticles, transform.position + Vector3.up, Quaternion.identity);
        freeze.transform.position = transform.position;
        Destroy(freeze, FreezeTime);

        Color customColor = new Color(0, 0.9556165f, 1, 1);
        gameObject.GetComponent<NavMeshAgent>().isStopped = true;
        foreach(Renderer mats in RendMaterials)
        {
            mats.GetComponent<Renderer>().material.SetColor("_BaseColor", customColor);
            mats.GetComponent<Renderer>().material.SetColor("_1st_ShadeColor", customColor);
        }
        
        isFrozen = true;
        yield return new WaitForSeconds(FreezeTime);
        isFrozen = false;
        gameObject.GetComponent<NavMeshAgent>().isStopped = false;
        foreach (Renderer mats in RendMaterials)
        {
            mats.GetComponent<Renderer>().material.SetColor("_BaseColor", Color.white);
            mats.GetComponent<Renderer>().material.SetColor("_1st_ShadeColor", Color.white);
        }
        
    }
    ///freeze

    // so enemy cant attack as soon as spawned
    public IEnumerator WaitBeforeAttack()
    {
        alreadyAttacked = true;
        yield return new WaitForSeconds(1.5f);
        alreadyAttacked = false;
    }
    //

    Vector3 wanderTarget = Vector3.zero;
    public void Wander()
    {
        float wanderRadius = 100;
        float wanderDistance = 50;
        float wanderJitter = 2;

        //determine a location on a circle 
        wanderTarget += new Vector3(Random.Range(-1.0f, 1.0f) * wanderJitter,
                                        0,
                                        Random.Range(-1.0f, 1.0f) * wanderJitter);
        wanderTarget.Normalize();
        //project the point out to the radius of the cirle
        wanderTarget *= wanderRadius;

        //move the circle out in front of the agent to the wander distance
        Vector3 targetLocal = wanderTarget + new Vector3(0, 0, wanderDistance);
        //work out the world location of the point on the circle.
        Vector3 targetWorld = this.gameObject.transform.InverseTransformVector(targetLocal);

        agent.SetDestination(targetWorld);
        
    }


    //will chase the player if in sight range
    public virtual void ChasePlayer()
    {
        agent.SetDestination(player.position);
        
    }


    //will attack the player if in attack range
    public virtual void AttackPlayer()
    {
        
    }


    //destorys enemy
    public virtual void DestroyEnemy()
    {
        if (IsRogueLite == true )
        {
            if (roomspawn != null)
            roomspawn.RemoveEnemy(Enemy);

            if (bargespawn != null)
                bargespawn.RemoveEnemy(Enemy);
        }
        

        Destroy(Enemy);
        
        //only for the roguelite mode to check if it is the roguelite mode and remove from the room list
        

    }

    //resets the attack when called
    public virtual void ResetAttack()
    {
        alreadyAttacked = false;
    }


    //draws gizmos that you can see in the scene view when selecting the enemy
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }

}
