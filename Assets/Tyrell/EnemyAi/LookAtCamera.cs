using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{

    private void Update()
    {
        gameObject.transform.LookAt(Camera.main.transform);
    }
}
