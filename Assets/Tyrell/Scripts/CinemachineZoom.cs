using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CinemachineZoom : MonoBehaviour
{
    public static CinemachineZoom Instance { get; private set; }

    CinemachineVirtualCamera CVCamera;

    private void Awake()
    {
        Instance = this;
        CVCamera = GetComponent<CinemachineVirtualCamera>();
    }

    private void Start()
    {
        ZoomIn();
    }

    public void ZoomOut()
    {
        CinemachineTransposer CT = CVCamera.GetCinemachineComponent<CinemachineTransposer>();
        CT.m_FollowOffset = new Vector3(-10, 40, -10);

    }

    public void ZoomIn()
    {
        CinemachineTransposer CT = CVCamera.GetCinemachineComponent<CinemachineTransposer>();
        CT.m_FollowOffset = new Vector3(-10, 30, -10);

    }

    
}
