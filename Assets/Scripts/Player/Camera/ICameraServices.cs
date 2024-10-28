using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICameraService
{

 
    public abstract void SpawnCamera(Vector2 position,Camera cam);
    public abstract void SetCameraLookAt(Transform lookAt);
    public abstract void SetCameraFollow();

    public abstract void UpdateCamera(IPlayerInputService playerInputService, Camera cam);

    
}
