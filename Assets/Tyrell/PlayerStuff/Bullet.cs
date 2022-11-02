using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Damage;
    public float Speed;

    public float explosiveArea = 0;
    public GameObject explosiveRemnants;
    public float freezeTime = 0;


    int pierceCount = 0;
    int ricochetCount = 0;
    

    //these set the bool for the upgrades, if the upgrades are equipped they should be true, otherwise stay false
    public bool isCritical;
    public bool isRicochet;
    public bool isPierce;

    //set bonuses
    public bool isArmorPiercer;
    public bool isMegaRicochet;
    public bool isExplosionMagnet;
    public bool isSeeking;
    public bool isLifeSteal;
    public bool isUltraFreeze;



    public Collider ricochet;
    public Collider Pierce;

    public LayerMask WhatIsEnemy;
    public LayerMask WhatisWall;

    public Transform TipOfBullet;

    public GameObject Explosion;
    public GameObject FreezeExplosion;
    //damage spawn is the where the damage popup will spawn
    float damageSpawn;

    public Upgradeables _upgrades;
    public PlayerHealth _playerHealth;
    public Rigidbody rb;

    public GameObject _bulletHitParticles;


    public AudioSource aSource;
    public AudioClip aClip;

    void Start()
    {
        ricochet.enabled = isRicochet;
        Pierce.enabled = !isRicochet;
        _upgrades.GetComponent<Upgradeables>();
    }


     void Update()
    {
        if (ricochetCount > _upgrades.ricochetCountUpgraded)
        {
            Destroy(gameObject);
            ricochetCount = 0;
        }
        if (pierceCount > _upgrades.PierceCountUpgraded)
        {
            Destroy(gameObject);
            pierceCount = 0;

        }

        if (isSeeking)
        {
            SearchTarget();
            
        }
       

    }

    void SearchTarget()
    {
        Collider[] enemies = Physics.OverlapSphere(transform.position, explosiveArea * 10, WhatIsEnemy);
        Collider bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = transform.position;
        foreach (Collider potentialTarget in enemies)
        {
            Vector3 directionToTargets = potentialTarget.gameObject.transform.position - currentPosition;
            float dSqrToTarget = directionToTargets.sqrMagnitude;
            if (dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                bestTarget = potentialTarget;
            }


        }

        if (bestTarget != null)
        {
            SeekToTarget(bestTarget);
        }
    }

    void SeekToTarget(Collider Target)
    {
        Vector3 directionToTarget = Target.transform.position - transform.position;
        Vector3 currentDirection = transform.forward;
        float maxTurnSpeed = 360f; // degrees per second
        Vector3 resultingDirection = Vector3.RotateTowards(currentDirection, directionToTarget, maxTurnSpeed * Mathf.Deg2Rad * Time.deltaTime, 1f);
        transform.rotation = Quaternion.LookRotation(resultingDirection);
        rb.velocity = resultingDirection * Speed;
    }

    void StealLife()
    {
        int lifeStolen = Mathf.RoundToInt(Damage / 10);
        _playerHealth.GetComponent<PlayerHealth>().GainHealth(lifeStolen);
    }


    void OnTriggerEnter(Collider collision)
    {
        //aSource.PlayOneShot(aClip);
        pierceCount++;
        GameObject _particle = Instantiate(_bulletHitParticles, TipOfBullet.position, Quaternion.identity);
        _particle.transform.localScale += this.transform.localScale;
        Destroy(_particle, 0.5f);

        if (collision.gameObject.tag == "Boss")
        {
            DamageToBoss(collision.gameObject);

            if (isLifeSteal)
            {
                StealLife();
            }
            

        }



        if (collision.gameObject.tag == "Enemy")
        {
            DamageToEnemy(collision.gameObject);

            if (freezeTime > 0)
            {
                collision.gameObject.GetComponent<EnemyAiController>().StartFrozen(freezeTime);
            }
            if (isLifeSteal)
            {
                StealLife();
            }


        }



        if ((WhatisWall.value & 1 << collision.gameObject.layer) != 0 && isArmorPiercer == false
            || collision.gameObject.tag == "Shield" && isArmorPiercer == false) //== 1<<collision.gameObject.layer)
        {
            
            Destroy(gameObject);
        }

        if (_upgrades.explosiveCountUpgraded > 0)
        {
            CheckForEnemies();
            
        }

    }

    void OnCollisionEnter(Collision collision)
    {
        //aSource.PlayOneShot(aClip);
        ricochetCount++;
        transform.forward = rb.velocity;
        GameObject _particle = Instantiate(_bulletHitParticles, TipOfBullet.position, Quaternion.identity);
        _particle.transform.localScale += this.transform.localScale;
        Destroy(_particle, 0.5f);
        ///Mega Ricochet set bonus
        if (isMegaRicochet)
        {
            Damage = Damage * 2;
            rb.AddForce(rb.velocity / 5 , ForceMode.VelocityChange);
        }
        ///

        if (collision.gameObject.tag == "Enemy")
        {
            DamageToEnemy(collision.gameObject);


            if (freezeTime > 0)
            {
                collision.gameObject.GetComponent<EnemyAiController>().StartFrozen(freezeTime);
            }
            if (isLifeSteal)
            {
                StealLife();
            }
            Destroy(this.gameObject);

        }

        if (collision.gameObject.tag == "Boss")
        {
            DamageToBoss(collision.gameObject);
            if (isLifeSteal)
            {
                StealLife();
            }
            
            Destroy(this.gameObject);
        }

        if (_upgrades.explosiveCountUpgraded > 0)
        {
            CheckForEnemies();
        }

    }

    void DamageToEnemy(GameObject enemy)
    {
        DamageDealt("DamageDealt");
        enemy.gameObject.GetComponent<EnemyHealth>().EnemyTakeDamage(Damage, isCritical);
    }
    void DamageToBoss(GameObject boss)
    {
        DamageDealt("DamageDealt");
        boss.gameObject.GetComponent<BossHealth>().EnemyTakeDamage(Damage, isCritical);
    }


    public void DamageDealt(string Name)
    {
        AchievementManager.instance.AddAchievementProgress(Name, Damage);
    }


    /// <summary>
    /// for the explosion, will check for colliders in the physics overlapsphere
    /// will only check for layermask what is enemy
    /// </summary>
    void CheckForEnemies()
    {
        SpawnExplosion();
        ///Explosion Magnet set bonus
        if (isExplosionMagnet)
        {
            FireRemnants();

        }
        ///ultraFreeze
        if (isUltraFreeze)
        {
            SpawnFreezeExplosion();

        }

        Collider[] colliders = Physics.OverlapSphere(transform.position, explosiveArea, WhatIsEnemy);
        foreach (Collider collider in colliders)
        {
            if(collider.CompareTag("Enemy"))
            {                
                collider.gameObject.GetComponent<EnemyHealth>().EnemyTakeDamage(Mathf.RoundToInt(Damage / 2), isCritical);

                ///ultraFreeze
                if (isUltraFreeze)
                {
                    collider.gameObject.GetComponent<EnemyAiController>().StartFrozen(freezeTime / 2);
                }
            }
            else if(collider.CompareTag("Boss"))
            {                
                collider.gameObject.GetComponent<BossHealth>().EnemyTakeDamage(Mathf.RoundToInt(Damage / 2), isCritical);               
            }

        }
    }

    void SpawnFreezeExplosion()
    {
        GameObject explosion = Instantiate(FreezeExplosion, TipOfBullet.position, Quaternion.identity);
        explosion.transform.localScale = new Vector3(explosiveArea, explosiveArea, explosiveArea);
        Destroy(explosion, 1.5f);
    }


    void SpawnExplosion()
    {
        GameObject explosion = Instantiate(Explosion, TipOfBullet.position, Quaternion.identity);
        explosion.transform.localScale = new Vector3(explosiveArea, explosiveArea, explosiveArea);
        Destroy(explosion, 1.5f);
    }


    void FireRemnants()
    {
        GameObject remnants = Instantiate(explosiveRemnants, transform.position, Quaternion.Euler(-90, 0, 0));
        ParticleSystem ps = remnants.GetComponent<ParticleSystem>();
        var sh = ps.shape;
        sh.radius = explosiveArea / 2;
        EnvironmentalDangers ed = remnants.GetComponent<EnvironmentalDangers>();
        ed.Damage = Mathf.RoundToInt(Damage / 2);
        Destroy(remnants, 5);
    }
    


}
