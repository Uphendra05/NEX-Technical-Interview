using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public interface IPlayerInputService
    {
        public Vector2 InputAxis { get; }
        public Vector2 MousePosition { get; }

        public event Action OnMouseDown;
        public event Action OnMouseUp;

    }

