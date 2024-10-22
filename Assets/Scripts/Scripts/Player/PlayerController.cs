using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour 
{


    public PlayerSO playerScriptabelObject;


    private Dictionary<EPlayerState, BaseState> m_ListOfStates = new Dictionary<EPlayerState, BaseState>();
    private EPlayerState CurrentStateID = EPlayerState.IDLE;
    private PlayerInputService PlayerInputService;
    private IPlayerInputService m_IPlayerInputService;

    void Start()
    {
        PlayerInputService = new PlayerInputService();        
        m_IPlayerInputService = PlayerInputService;


        AddState(EPlayerState.MOVE, new MoveState());

        ChangeState(EPlayerState.MOVE); 
    }


    void Update()
    {
        PlayerInputService.UpdateInputs();
       
    }

    private void FixedUpdate()
    {
        foreach (var state in m_ListOfStates)
        {
            state.Value.FixedUpdate();
        }
    }







    public void AddState(EPlayerState eState, BaseState state)
    {
        state.Init(this, m_IPlayerInputService);

        m_ListOfStates.Add(eState, state);
    }

    public void RemoveState(EPlayerState eState)
    {
        m_ListOfStates.Remove(eState);
    }

    public void ChangeState(EPlayerState eState)
    {
       
        CurrentStateID = eState;

        if (CurrentStateID != EPlayerState.IDLE)
        {
            GetCurrentState().Start();
        }
    }

    public BaseState GetState(EPlayerState eState)
    {
        return m_ListOfStates[eState];
    }

    public BaseState GetCurrentState()
    {
        return m_ListOfStates[CurrentStateID];
    }
}
