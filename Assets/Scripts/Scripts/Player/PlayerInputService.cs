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


    private Vector2 inputAxis = Vector2.zero;
    private Vector2 mousPosition = Vector2.zero;
   


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
    }


}
