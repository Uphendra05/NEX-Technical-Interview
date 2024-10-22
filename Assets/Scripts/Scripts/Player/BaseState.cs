using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseState
{
    public virtual void Start() { }
    public virtual void Update() { }
    public virtual void FixedUpdate() { }
   
    public void Init(PlayerController playerController,  IPlayerInputService playerInputService)
    {
        m_PlayerController = playerController;
        m_InputService = playerInputService;
    }

    protected PlayerController m_PlayerController;
    protected IPlayerInputService m_InputService;
}

