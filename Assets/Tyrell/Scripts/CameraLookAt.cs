using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLookAt : MonoBehaviour
{
    public MousePosition mousePos;

    private void Start()
    {
        mousePos.GetComponent<MousePosition>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = mousePos.WorldPosition;
        pos.y = 2;

        this. gameObject.transform.position = pos;

    }
}
