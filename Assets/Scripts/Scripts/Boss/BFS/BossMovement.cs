using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BossMovement : MonoBehaviour
{
    public FindPath pathfinding;
    public Node startNode;
    public Node endNode;
   
    public float speed = 2.0f;
    public bool isEnraged = false;
    public GameObject player;

    public List<Node> nodes = new List<Node>();

    public List<Node> currentPath = new List<Node>();

    public int currentTargetIndex = 0;

    public GameService gameLoop;

    void Start()
    {
        player = gameLoop.m_PlayerController.gameObject;

        
    }

   




   
}
