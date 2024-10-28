using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CameraView : MonoBehaviour
{
    public Camera m_Camera;

    private ICameraService m_CameraService;
    private IPlayerInputService m_InputService;


    [Inject]
    private void Construct(ICameraService cameraService, IPlayerInputService playerInputService)
    {
        m_CameraService = cameraService;
        m_InputService = playerInputService;
    }

    private void Reset()
    {
        m_Camera = GetComponentInChildren<Camera>();
    }

    public void Start()
    {

        m_CameraService.SetCameraFollow();
        m_CameraService.SpawnCamera(Vector2.zero, m_Camera);
    }

    public void Update()
    {
        m_CameraService.UpdateCamera(m_InputService, m_Camera);
    }
}
