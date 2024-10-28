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
       // m_InputService.OnDash += Dodge;
    }

    public override void Update()
    {
        
    }

    public override void FixedUpdate()
    {
        HandleFalling();
        if (m_InputService.InputAxis.magnitude == 0)
        {
            m_PlayerController.ChangeState(EPlayerState.IDLE);

            HandleRotation();
            return;
            
        }

        HandleMove();
        HandleRotation();
    }

    public override void OnDestroy()
    {
        m_InputService.OnDash -= Dodge;

    }


    private void HandleMove()
    {
        m_PlayerController.ChangeState(EPlayerState.MOVE);

        Vector3 cameraForward = Camera.main.transform.forward;
        cameraForward.y = 0f; 
        cameraForward.Normalize();

        Vector3 movementDirection = (m_InputService.InputAxis.x * Camera.main.transform.right) + (m_InputService.InputAxis.z * cameraForward);
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

    private void Dodge()
    {
        m_PlayerController.ChangeState(EPlayerState.DASH);
    }

    private void HandleFalling()
    {
        RaycastHit hit;
        if (Physics.Raycast(m_PlayerController.transform.position, Vector3.down, out hit, 22f, m_PlayerController.playerScriptabelObject.whatisGround))
        {
            m_PlayerController.playerScriptabelObject.isGrounded = true;
            m_PlayerController.playerScriptabelObject.lastPos = m_PlayerController.transform.position;


        }
        else
        {
            m_PlayerController.playerScriptabelObject.isGrounded = false;
        }


        if (!m_PlayerController.playerScriptabelObject.isGrounded)
        {
            m_PlayerController.playerScriptabelObject.gravity = -91.8f;
            m_PlayerController.playerScriptabelObject.speed = 0.1f;
        }
        else
        {
            m_PlayerController.playerScriptabelObject.gravity = 0f;
            m_PlayerController.playerScriptabelObject.speed = 5;

        }
    }
}
