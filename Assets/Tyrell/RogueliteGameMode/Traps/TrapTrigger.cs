using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapTrigger : MonoBehaviour
{

    bool canBeTriggered = true;
    public Animator _animator;

    public float ResetTime;
    public float trapWaitTime;

    AudioSource aSource;
    public AudioClip aClip;

    private void Start()
    {
        aSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player") && canBeTriggered)
        {
            
            canBeTriggered = false;
            StartCoroutine(WaitForTrap());


        }


    }

    IEnumerator WaitForTrap()
    {
        yield return new WaitForSeconds(trapWaitTime);
        aSource.PlayOneShot(aClip);
        _animator.SetTrigger("Trigger");
        StartCoroutine(ResetTrap());
    }
    IEnumerator ResetTrap()
    {
        yield return new WaitForSeconds(ResetTime);
        canBeTriggered = true;


    }
    

}
