using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BossView : MonoBehaviour
{
    [SerializeField] private BossSO bossSO;

    private IBossService m_BossService;

    [Inject]
    private void Construct(IBossService bossService)
    {
        m_BossService  = bossService;
    }


    void Start()
    {
        m_BossService.StartBossPhase();
    }

    void Update()
    {
        m_BossService.UpdateBossPhase();
    }

   
}
