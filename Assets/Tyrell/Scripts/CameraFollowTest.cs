using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowTest : MonoBehaviour
{
    public Transform player;

    public float smoothedSpeed =  10.5f;
    public Vector3 offset;

    private void Start()
    {
        if(GameObject.FindWithTag("Player") != null)
        {
            player = GameObject.FindWithTag("Player").transform;
        }
    }
    void FixedUpdate()
    {
        Vector3 desiredPosition = player.transform.position + offset;
        Vector3 smoothedposition = Vector3.Lerp(transform.position, desiredPosition, smoothedSpeed * Time.deltaTime);
        transform.position = smoothedposition;
    }
}
