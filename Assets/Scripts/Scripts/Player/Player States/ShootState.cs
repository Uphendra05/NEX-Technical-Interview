using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootState : BaseState
{
    public ShootState()
    {
    }

    public override void Start()
    {
        m_InputService.OnMouseDown += Shoot;

    }

    public override void Update()
    {
    }

    public override void FixedUpdate()
    {
        
    }
    public override void OnDestroy()
    {
        m_InputService.OnDash -= Shoot;

    }

    private void Shoot()
    {
        Debug.Log("Player Shooting");
    }
}
