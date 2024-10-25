using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    public FindPath pathfinding;
    public Node startNode;
    public Node endNode;
    public Node enragedStartNode;
    public Node enragedNode;
    public float speed = 2.0f;
    public bool isEnraged = false;
    public GameObject player;

    public List<Node> nodes = new List<Node>();

    private List<Node> currentPath = new List<Node>();

    public int currentTargetIndex = 0;

    void Start()
    {
        pathfinding = new FindPath(startNode,endNode);
        currentPath = pathfinding.FindBFSPath();
    }

    void Update()
    {
        if (isEnraged == false)
        {
            enragedStartNode = currentPath[currentTargetIndex];

            if (currentPath != null && currentPath.Count > 0)
            {
                Debug.Log("IN Top");
                Vector3 targetPosition = currentPath[currentTargetIndex].position;
                targetPosition.y = 0;
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
                
                transform.LookAt(new Vector3(player.transform.position.x,transform.position.y, player.transform.position.z));



                if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
                {
                    Debug.Log("IN Mid");
                    currentTargetIndex++;

                    if (currentTargetIndex >= currentPath.Count)
                    {
                        Debug.Log("IN Low");
                        Node newStartNode = currentPath[currentTargetIndex - 1];
                        Node newEndNode = GetNewEndNode();


                        pathfinding = new FindPath(newStartNode, newEndNode);
                        currentPath = pathfinding.FindBFSPath();
                        currentTargetIndex = 0;
                    }


                }
            }
        }
        else
        {
            Node newStartNode = enragedStartNode;

            pathfinding = new FindPath(currentPath[currentPath.Count-1], enragedNode);
            currentPath = pathfinding.FindBFSPath();



            if (currentPath != null && currentPath.Count > 0)
            {
                Debug.Log("IN Top");
                Vector3 targetPosition = enragedNode.position;
                targetPosition.y = 0;
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

                if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
                {
                    Debug.Log("In Middle of Arena");
                    //currentTargetIndex++;

                }

            }
        }
    }


  


    Node GetNewEndNode()
    {
        int randomNode = Random.Range(1, nodes.Count - 1);

        
        
        return nodes[randomNode];
    }
}
