using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerController : MonoBehaviour 
{


    public PlayerSO playerScriptabelObject;
    public bool isInvincible = false;
    public Camera playerCam;
    private Dictionary<EPlayerState, BaseState> m_ListOfStates = new Dictionary<EPlayerState, BaseState>();
    public EPlayerState CurrentStateID = EPlayerState.IDLE;

    private IPlayerInputService m_IPlayerInputService;
    private IRaycastService m_RaycastService;
    private IPlayerHealthService m_PlayerHealthService;

    [Inject] 
    public void Construct(IPlayerInputService playerInputService, 
        IRaycastService raycastService,IPlayerHealthService playerHealthService )
    {
        m_IPlayerInputService = playerInputService;
        m_RaycastService = raycastService;
        m_PlayerHealthService = playerHealthService;
    }


    void Start()
    {
        playerScriptabelObject.rb = this.GetComponent<Rigidbody>();
        AddState(EPlayerState.MOVE, new MoveState());
        AddState(EPlayerState.DASH, new DodgeState());
        AddState(EPlayerState.SHOOT, new ShootState());

        ChangeState(EPlayerState.MOVE);

        foreach (var state in m_ListOfStates)
        {
            state.Value.Start();
        }

    }


    void Update()
    {
        m_IPlayerInputService.UpdateInputs();

        foreach (var state in m_ListOfStates)
        {
            state.Value.Update();
        }

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
        state.Init(this, m_IPlayerInputService, m_RaycastService);

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


    // Still need to call this function
    public void GameCleanup()
    {
        foreach (var state in m_ListOfStates)
        {
            state.Value.OnDestroy();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Heal"))
        {
            Actions.onHeal(100f);
        }
    }
}
