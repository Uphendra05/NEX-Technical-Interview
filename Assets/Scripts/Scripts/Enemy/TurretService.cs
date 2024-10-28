using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class TurretService : ITurretService
{
    [Inject] private TurretSO turretSO;
    private TurretView m_TurretView;
    public void Start(TurretView turretView)
    {
        m_TurretView = turretView;
    }

    public void Update()
    {
        LookPlayer();
    }

    public void Cleanup()
    {
        throw new System.NotImplementedException();
    }

    void LookPlayer()
    {
        Vector3 targetPosition = turretSO.target.transform.position;
        targetPosition.y = turretSO.target.transform.position.y;
        m_TurretView.transform.LookAt(targetPosition);
    }

    

}
