using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameService : MonoBehaviour
{

    [Inject] private CameraSO cameraSO;

    public PlayerController m_PlayerController;
    private DiContainer m_Container;
    public GameObject boosGameobjec;
    public GameObject levelGameobjec;
    public GameObject cameraGameobject; 

    [Inject]
    private void Construct(DiContainer container)
    {
        m_Container = container;
    }
    private void Awake()
    {
        m_PlayerController = m_Container.InstantiatePrefabForComponent<PlayerController>(cameraSO.player);
        cameraSO.target = m_PlayerController.gameObject;

    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
