using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BossView : MonoBehaviour
{
    [HideInInspector]
    [Inject] public BossSO bossSO;

    private IBossService m_BossService;
    public GameObject waypointParent;
    public GameObject player;

    [HideInInspector]
    public BossMovement bossData;

    [Inject]
    private void Construct(IBossService bossService)
    {
        m_BossService  = bossService;
    }

    private void Awake()
    {
        bossData = this.GetComponent<BossMovement>();

       
    }

    void Start()
    {
        m_BossService.StartBossPhase(this);
    }

    void Update()
    {
        m_BossService.UpdateBossPhase();
    }

   
}
