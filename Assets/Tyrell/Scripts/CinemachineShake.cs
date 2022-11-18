using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CinemachineShake : MonoBehaviour
{
    public static CinemachineShake Instance { get; private set; }

    CinemachineVirtualCamera CVCamera;

    float shakeTimer;

    private void Awake()
    {
        Instance = this;
        CVCamera = GetComponent<CinemachineVirtualCamera>();
    }

    public void ShakeCamera(float Intensity, float time)
    {
        CinemachineBasicMultiChannelPerlin CBMCP =
            CVCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        CBMCP.m_AmplitudeGain = Intensity;
        shakeTimer = time;

    }


    private void Update()
    {
        if(shakeTimer > 0)
        {

            shakeTimer -= Time.deltaTime;
            if(shakeTimer <= 0f)
            {
                CinemachineBasicMultiChannelPerlin CBMCP =
                CVCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
                CBMCP.m_AmplitudeGain = 0f;
                
            }
        }


    }


}
