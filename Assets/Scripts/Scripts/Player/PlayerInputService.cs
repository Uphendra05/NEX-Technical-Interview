using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputService : IPlayerInputService
{
    public Vector2 InputAxis { get { return inputAxis; } }
    public Vector2 MousePosition { get { return mousPosition; } }

    public event Action OnMouseDown = delegate { };
    public event Action OnMouseUp = delegate { };
    public event Action OnDash = delegate { };


    private Vector2 inputAxis = Vector2.zero;
    private Vector2 mousPosition = Vector2.zero;

    public KeyCode dashKey = KeyCode.Space;

    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";

    public void UpdateInputs()
    {
        inputAxis.x = Input.GetAxisRaw(HORIZONTAL);
        inputAxis.y = Input.GetAxisRaw(VERTICAL);

        inputAxis.Normalize();

        mousPosition = Input.mousePosition;


        if (Input.GetMouseButtonDown(0))
        {
            OnMouseDown.Invoke();
        }
        if (Input.GetMouseButtonDown(1))
        {
            OnMouseUp.Invoke();
        }
        if(Input.GetKeyDown(dashKey))
        {
            OnDash.Invoke();
        }
    }

    public Vector3 GetMouseDirection()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, Camera.main.nearClipPlane));
        Vector3 direction = (worldPos - Camera.main.transform.position).normalized;
        return direction;

    }
}
