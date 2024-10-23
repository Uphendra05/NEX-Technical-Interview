using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject.SpaceFighter;

public class MoveState : BaseState
{
    public MoveState()
    {

    }

    public override void Start()
    {
        
    }

    public override void Update()
    {
      
    }

    public override void FixedUpdate()
    {
        HandleMove();
        HandleRotation();
    }

    public override void OnDestroy()
    {


    }


    private void HandleMove()
    {
        Vector3 cameraForward = Camera.main.transform.forward;
        cameraForward.y = 0f; 
        cameraForward.Normalize();

        Vector3 movementDirection = (m_InputService.InputAxis.x * Camera.main.transform.right) + (m_InputService.InputAxis.y * cameraForward);
        movementDirection.Normalize();

        Vector3 velocity = movementDirection * m_PlayerController.playerScriptabelObject.speed;

        m_PlayerController.playerScriptabelObject.rb.AddForce(velocity, ForceMode.VelocityChange);
        float drag = 10f;
        m_PlayerController.playerScriptabelObject.rb.drag = drag;
       // Debug.Log("Input X : " + m_InputService.InputAxis.x + "Input Y : " + m_InputService.InputAxis.y);

    }

    private void HandleRotation()
    {
        Vector3? hitPoint = m_RaycastService.GetRaycastHitDir();
        if (hitPoint.HasValue)
        {
            Vector3 target = hitPoint.Value;
            target.y = m_PlayerController.transform.position.y;
            m_PlayerController.transform.LookAt(target);
        }
    }
}
