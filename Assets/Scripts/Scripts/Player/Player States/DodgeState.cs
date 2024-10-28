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
            m_PlayerController.StartCoroutine(DoDash());
        }
       



    }


    private IEnumerator DoDash()
    {


        float elapsedTime = 0f;
        Vector3 startPos = m_PlayerController.transform.position;
        Vector3 endPos = startPos + m_PlayerController.transform.forward * m_PlayerController.playerScriptabelObject.dashDistance;

        while (elapsedTime < m_PlayerController.playerScriptabelObject.dashTime)
        {
            float t = elapsedTime / m_PlayerController.playerScriptabelObject.dashTime;


            float y = Mathf.Sin(t * Mathf.PI);
            Vector3 pos = Vector3.Lerp(startPos, endPos, t);
            pos.y += y * 0.5f;
            m_PlayerController.transform.position = pos;

            elapsedTime += Time.deltaTime;
            m_PlayerController.isInvincible = true;
            yield return null;
        }
        m_PlayerController.isInvincible = false;

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
