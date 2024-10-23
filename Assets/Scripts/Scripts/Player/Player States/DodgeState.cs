using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeState : BaseState
{
    public DodgeState()
    {
        
    }

    public override void Start()
    {
        m_PlayerController.playerScriptabelObject.canDash = true;
        m_InputService.OnDash += Dash;
    }

    public override void Update()
    {
       
    }

    public override void FixedUpdate()
    {
        

    }

    public override void OnDestroy()
    {

        m_InputService.OnDash -= Dash;
    }

    public void Dash()
    {
        if (m_PlayerController.playerScriptabelObject.canDash == true)
        {
            m_PlayerController.playerScriptabelObject.canDash = false;
            Vector3 cameraRelativeDirection = CamRelativeDirection(m_InputService.InputAxis, Camera.main);
            Vector3 startPos = m_PlayerController.transform.position;
            Vector3 endPos;

            if (m_InputService.InputAxis.magnitude == 0)
            {
                endPos = startPos + m_PlayerController.transform.forward * m_PlayerController.playerScriptabelObject.dashDistance;
                m_PlayerController.StartCoroutine(DoDash(endPos));
            }
            else
            {
                endPos = m_PlayerController.transform.position + cameraRelativeDirection.normalized * m_PlayerController.playerScriptabelObject.dashDistance;
                RaycastHit hit;
                if (Physics.Raycast(m_PlayerController.transform.position, cameraRelativeDirection, out hit, m_PlayerController.playerScriptabelObject.obstacleCheckDistance))
                {
                    Debug.Log(hit.point);
                    endPos = hit.point;
                }
            }

            m_PlayerController.StartCoroutine(DoDash(endPos));
        }
       






    }



    private IEnumerator DoDash(Vector3? endPosOverride = null)
    {
       // m_InputService.OnDash -= Dash;

        float elapsedTime = 0f;
        Vector3 startPos = m_PlayerController.transform.position;
        Vector3 endPos = endPosOverride ?? startPos + m_PlayerController.transform.forward * m_PlayerController.playerScriptabelObject.dashDistance; // Use override if provided, else use default

        while (elapsedTime < m_PlayerController.playerScriptabelObject.dashTime)
        {
            float t = elapsedTime / m_PlayerController.playerScriptabelObject.dashTime;

            // Calculate Y-axis sinusoidal offset for dash arc effect
            float y = Mathf.Sin(t * Mathf.PI);
            Vector3 pos = Vector3.Lerp(startPos, endPos, t);
            pos.y += y * 0.5f;  // Add vertical motion for the dash arc

            m_PlayerController.transform.position = pos;

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        m_PlayerController.transform.position = endPos;
        yield return new WaitForSeconds(m_PlayerController.playerScriptabelObject.dashCooldown);
        m_PlayerController.playerScriptabelObject.canDash = true;
    }

    private Vector3 CamRelativeDirection(Vector3 direction, Camera camera)
    {

        Vector3 cameraForward = camera.transform.forward;
        cameraForward.y = 0f;
        cameraForward.Normalize();


        Vector3 cameraRight = camera.transform.right;
        cameraRight.y = 0f;
        cameraRight.Normalize();


        Vector3 cameraRelativeDirection = cameraForward * direction.z + cameraRight * direction.x;
        cameraRelativeDirection.y = 0f;
        cameraRelativeDirection.Normalize();

        return cameraRelativeDirection;
    }
}
