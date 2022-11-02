using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class WardenBossAnimation : MonoBehaviour
{
    public Animator _animator;

    public void PlayChargeAttack()
    {
        _animator.SetTrigger("ChargeAttack");
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
