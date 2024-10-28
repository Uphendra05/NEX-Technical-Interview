using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IPlayerInputService
{
    public Vector3 InputAxis { get; }
    public Vector2 MousePosition { get; }

    public event Action OnMouseDown;
    public event Action OnMouseUp;
    public event Action OnDash;
   
    public abstract void UpdateInputs();
    public abstract Vector3 GetMouseDirection();

}

