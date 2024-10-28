using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBossState
{

    public virtual void Start() { }
    public virtual void Update() { }
    public virtual void FixedUpdate() { }
    public virtual void OnDestroy() { }


    protected BossView m_BossView;

    public void Init(BossView bossView )
    {
        m_BossView = bossView;
    }



}
