using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    public FindPath pathfinding;
    public Node startNode;
    public Node endNode;
    public Node _endNode;
    public float speed = 2.0f;

    public List<Node> currentPath = new List<Node>();
    public int currentTargetIndex = 0;

    void Start()
    {
        pathfinding = new FindPath(startNode,endNode);
        currentPath = pathfinding.FindBFSPath();
    }

    void Update()
    {
        
        if (currentPath != null && currentPath.Count > 0)
        {
            Debug.Log("IN Top");
            Vector3 targetPosition = currentPath[currentTargetIndex].position;
            targetPosition.y = 0;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                Debug.Log("IN Mid");
                currentTargetIndex++;

                if (currentTargetIndex >= currentPath.Count)
                {
                    Debug.Log("IN Low");
                    Node newStartNode = currentPath[currentTargetIndex - 1];
                    Node newEndNode = _endNode; 

                    
                    pathfinding = new FindPath(newStartNode, newEndNode);

                    currentPath = pathfinding.FindBFSPath(); 
                    currentTargetIndex = 0; 
                }


            }
        }
    }

    //Node GetNewEndNode()
    //{
    //    // Logic to get a new end node
    //    // Can be random or predetermined
    //    return /* some new end node */;
    //}
}
