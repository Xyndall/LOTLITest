using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidProjectile : MonoBehaviour
{
    public GameObject AcidPool;
    public float Speed = 5;
    const float minRotation = 1;
    const float maxRotation = 360;
    void Update()
    {
        transform.Translate(Vector3.forward * Speed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.layer == 9)
        {
            float acidRotation = Random.Range(minRotation, maxRotation);
            Quaternion rot = Quaternion.Euler(0,acidRotation,0);
            Instantiate(AcidPool, transform.position, rot);
            Destroy(gameObject);
        }  
    }
}
