using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BossService : IBossService
{


    private Dictionary<EBossState, BaseBossState> m_ListOfStates = new Dictionary<EBossState, BaseBossState>();

    public EBossState CurrentStateID = EBossState.MOVE ;

    

    public void StartBossPhase(BossView bossView)
    {
        AddState(EBossState.MOVE, new BossMoveState(), bossView);
        ChangeState(EBossState.MOVE);

        foreach (var state in m_ListOfStates)
        {
            state.Value.Start();
        }
    }

    public void UpdateBossPhase()
    {
        //Debug.Log("In Boss Update !");
        foreach (var state in m_ListOfStates)
        {
            state.Value.Update();
        }


    }

    public void Cleanup()
    {
        //Debug.Log("In Boss Cleanup !");

    }

    public void AddState(EBossState eState, BaseBossState state, BossView bossView)
    {
        state.Init(bossView);

        m_ListOfStates.Add(eState, state);
    }

    public void RemoveState(EBossState eState)
    {
        m_ListOfStates.Remove(eState);
    }

    public void ChangeState(EBossState eState)
    {

        CurrentStateID = eState;

        if (CurrentStateID != EBossState.IDLE)
        {
            GetCurrentState().Start();
        }
    }

    public BaseBossState GetState(EBossState eState)
    {
         return m_ListOfStates[eState];
    }

    public BaseBossState GetCurrentState()
    {
        return m_ListOfStates[CurrentStateID];
    }




}


public enum EBossState
{
    NONE = 0,
    IDLE = 1,
    MOVE = 2 ,
}