using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindPath
{
    public Node m_StartNode; 
    public Node m_EndNode;
    public FindPath(Node startNode, Node endNode)
    {
        m_StartNode = startNode;
        m_EndNode = endNode;

    }

    public List<Node> FindBFSPath()
    {
        Queue<Node> queue = new Queue<Node>();
        Dictionary<Node, Node> cameFrom = new Dictionary<Node, Node>();
        List<Node> path = new List<Node>();

        queue.Enqueue(m_StartNode);
        cameFrom[m_StartNode] = null;

        while (queue.Count > 0)
        {
            Node current = queue.Dequeue();

            if (current == m_EndNode)
            {
                while (current != null)
                {
                    path.Insert(0, current);
                    current = cameFrom[current];
                }
                break;
            }

            foreach (Node neighbor in current.neighbors)
            {
                if (!cameFrom.ContainsKey(neighbor))
                {
                    queue.Enqueue(neighbor);
                    cameFrom[neighbor] = current;
                }
            }
        }

        return path;
    }


}
