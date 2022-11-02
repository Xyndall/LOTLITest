using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boiler : MonoBehaviour
{
    float health = 100;

    public GameObject explosion;
    public Animator animator;

    public bool boilerDestroyed = false;

    public WardenBossManager boilerManager;

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerBullet"))
        {
            animator.SetTrigger("Hit");
            health -= other.GetComponent<Bullet>().Damage;
        }
    }

    private void Update()
    {
        if(health <= 0)
        {
            boilerManager.GetComponent<WardenBossManager>().boilerDestroyed++;
            GameObject _explosion = Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(_explosion, 2);
            Destroy(this.gameObject);
        }
    }

    private void SetColor()
    {
        GetComponent<Renderer>().material.SetColor("_BaseColor", Color.red);
    }
    private void ReSetColor()
    {
        GetComponent<Renderer>().material.SetColor("_BaseColor", Color.white);
    }



}
