using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Zenject.SpaceFighter;

public class CameraService : ICameraService
{
    [Inject] private CameraSO cameraSO ;

    private DiContainer m_Container;
    private PlayerController m_PlayerController;

    [Inject] 
    private void Construct(DiContainer container)
    {
        m_Container = container;
    }


    public void SetCameraFollow()
    {
        m_PlayerController = m_Container.InstantiatePrefabForComponent<PlayerController>(cameraSO.player);
        cameraSO.target = m_PlayerController.transform;
        
    }

    public void SetCameraLookAt(Transform lookAt)
    {
        throw new System.NotImplementedException();
    }

    public void SpawnCamera(Vector2 position, Camera cam)
    {
        cameraSO.followoffset = cam.transform.position - cameraSO.target.position;
    }

    public void UpdateCamera(IPlayerInputService playerInputService,Camera cam)
    {
        Vector3 mouseDir = playerInputService.GetMouseDirection();

        if (mouseDir.magnitude > cameraSO.deadzone)
        {
            cameraSO._mouseDir = mouseDir;
        }

        cameraSO.camePos = cameraSO._mouseDir * cameraSO.followdistance + (cameraSO.target.position + cameraSO.followoffset);
        cam.transform.position = Vector3.Lerp(cam.transform.position, cameraSO.camePos, Time.deltaTime * 10f);
    }
}
