using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePosition : MonoBehaviour
{


    public Vector3 ScreenPosition;
    public Vector3 WorldPosition;
    public LayerMask WhatIsGround;

    public bool isGameObject = false;

    // Update is called once per frame
    void Update()
    {
        ScreenPosition = Input.mousePosition;

        Ray ray = Camera.main.ScreenPointToRay(ScreenPosition);

        if(Physics.Raycast(ray, out RaycastHit hitData, 1000, WhatIsGround))
        {
            Vector3 pos = hitData.point;
            pos.y = 2;
            WorldPosition = pos;
        }

        
    }



}
