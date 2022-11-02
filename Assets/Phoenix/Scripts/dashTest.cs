using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dashTest : MonoBehaviour
{
    public PlayerControllerTest _script;

    //Dash Terms

    public float _dashSpeed = 20f;
    public float _dashTime = 0.25f;
    float _dashCooldown;

    private void Start()
    {
        _script.GetComponent<PlayerControllerTest>();
    }

    void Update()
    {
        // Dash Inputs
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (_dashCooldown <= 0)
            {
                StartCoroutine(Dash());
            }
        }

        _dashCooldown -= Time.deltaTime;

    }

    IEnumerator Dash()
    {
        float startTime = Time.time;

        while (Time.time < startTime + _dashTime)
        {
            _script._rb.AddForce(_script.transform.forward * _dashSpeed);
            _dashCooldown = 3;

            yield return null;
        }
    }
}
