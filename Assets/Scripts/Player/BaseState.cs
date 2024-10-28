using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseState
{
    public virtual void Start() { }
    public virtual void Update() { }
    public virtual void FixedUpdate() { }
    public virtual void OnDestroy() { }

    protected PlayerController m_PlayerController;
    protected IPlayerInputService m_InputService;
    protected IRaycastService m_RaycastService;

    public void Init(PlayerController playerController,  IPlayerInputService playerInputService,
        IRaycastService raycastService)
    {
        m_PlayerController = playerController;
        m_InputService = playerInputService;   
        m_RaycastService = raycastService;
    }

    
}

