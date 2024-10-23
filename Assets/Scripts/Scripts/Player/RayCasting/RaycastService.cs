using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class RaycastService : IRaycastService
{

    [Inject] public RaycastSO raycastSO;

    public Vector3? GetRaycastHitDir()
    {
        raycastSO.cam = Camera.main;
        Ray ray = raycastSO.cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hitInfo, 300f, raycastSO.rayGround))
        {
            return hitInfo.point;
        }
        return null;
    }

    
}
