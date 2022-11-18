using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAcidProjectile : MonoBehaviour
{
    public GameObject Projectile;
    public Transform FirePosition;
    GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    public void Fire()
    {
        Vector3 forward = player.transform.position - FirePosition.position;
        Quaternion rot = Quaternion.LookRotation(forward);
        Instantiate(Projectile,FirePosition.position,rot);
    }
}
