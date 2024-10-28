using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class DodgeState : BaseState
{
    public DodgeState()
    {
        
    }

    public override void Start()
    {
        m_PlayerController.playerScriptabelObject.canDash = true;
        m_InputService.OnDash += PlayerDash;
    }

    public override void Update()
    {
       
    }

    public override void FixedUpdate()
    {
        

    }

    public override void OnDestroy()
    {

        m_InputService.OnDash -= PlayerDash;
    }

    public void PlayerDash()
    {
        if (m_InputService.InputAxis.magnitude == 0)
        {

            Dash();
        }
        else
        {
            Dash2(m_InputService.InputAxis, m_PlayerController.playerCam);
        }
    }

    public void Dash()
    {

        if (m_PlayerController.playerScriptabelObject.canDash == true)
        {
            m_PlayerController.playerScriptabelObject.canDash = false;
            Vector3 endPos = m_PlayerController.transform.position +  m_PlayerController.transform.forward * m_PlayerController.playerScriptabelObject.dashDistance;


            RaycastHit hit;
            if (Physics.Raycast(m_PlayerController.transform.position,  m_PlayerController.transform.forward, out hit, m_PlayerController.playerScriptabelObject.obstacleCheckDistance))
            {
                Debug.Log(hit.point);
                endPos = hit.point;
            }
            m_PlayerController.StartCoroutine(DoDash(endPos));
        }
       



    }

    public void Dash2(Vector3 dashDirection, Camera camera)
    {
        if (m_PlayerController.playerScriptabelObject.canDash)
        {
            m_PlayerController.playerScriptabelObject.canDash = false;
            Vector3 cameraRelativeDirection = CamRelativeDirection(dashDirection, camera);
            Vector3 endPos = m_PlayerController.transform.position + cameraRelativeDirection.normalized * m_PlayerController.playerScriptabelObject.dashDistance;


            RaycastHit hit;
            if (Physics.Raycast(m_PlayerController.transform.position, cameraRelativeDirection, out hit, m_PlayerController.playerScriptabelObject.obstacleCheckDistance))
            {
                endPos = hit.point;
            }
            m_PlayerController.StartCoroutine(DoDash2(endPos));
        }

        if (m_PlayerController.playerScriptabelObject.rb.velocity == new Vector3(0, 0, 0))
        {
            return;
        }
    }


    private IEnumerator DoDash(Vector3 endPos)
    {
        float elapsedTime = 0f;
        Vector3 startPos = m_PlayerController.transform.position;

        while (elapsedTime < m_PlayerController.playerScriptabelObject.dashTime)
        {
            float t = elapsedTime / m_PlayerController.playerScriptabelObject.dashTime;

            float y = Mathf.Sin(t * Mathf.PI);
            Vector3 pos = Vector3.Lerp(startPos, endPos, t);
            pos.y += y * 0.5f;

            m_PlayerController.transform.position = pos;
            m_PlayerController.isInvincible = true;

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        m_PlayerController.isInvincible = false;
        m_PlayerController.transform.position = endPos;
        yield return new WaitForSeconds(m_PlayerController.playerScriptabelObject.dashCooldown);
        m_PlayerController.playerScriptabelObject.canDash = true;
    }


    private IEnumerator DoDash2(Vector3 endPos)
    {
        float elapsedTime = 0f;
        Vector3 startPos = m_PlayerController.transform.position;

        while (elapsedTime < m_PlayerController.playerScriptabelObject.dashTime)
        {
            float t = elapsedTime / m_PlayerController.playerScriptabelObject.dashTime;


            float y = Mathf.Sin(t * Mathf.PI);
            Vector3 pos = Vector3.Lerp(startPos, endPos, t);
            pos.y += y * 0.5f;

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

    private void OnDashEnd()
    {
        m_PlayerController.ChangeState(EPlayerState.MOVE);

    }
}
