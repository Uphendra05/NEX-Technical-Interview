using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Zenject.SpaceFighter;

public class CameraService : ICameraService
{
    [Inject] private CameraSO cameraSO ;


    public void SetCameraFollow()
    {
       // m_PlayerController = m_Container.InstantiatePrefabForComponent<PlayerController>(cameraSO.player);
       // cameraSO.target = m_PlayerController.transform;
        
    }

    public void SetCameraLookAt(Transform lookAt)
    {
        throw new System.NotImplementedException();
    }

    public void SpawnCamera(Vector2 position, Camera cam)
    {
        cameraSO.followoffset = cam.transform.position - cameraSO.target.transform.position;
    }

    public void UpdateCamera(IPlayerInputService playerInputService,Camera cam)
    {
        Vector3 mouseDir = playerInputService.GetMouseDirection();

        if (mouseDir.magnitude > cameraSO.deadzone)
        {
            cameraSO._mouseDir = mouseDir;
        }

        cameraSO.camePos = cameraSO._mouseDir * cameraSO.followdistance + (cameraSO.target.transform.position + cameraSO.followoffset);
        cam.transform.position = Vector3.Lerp(cam.transform.position, cameraSO.camePos, Time.deltaTime * 10f);
    }
}
