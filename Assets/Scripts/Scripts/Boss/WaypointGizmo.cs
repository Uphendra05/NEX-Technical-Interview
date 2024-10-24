using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointGizmo : MonoBehaviour
{
    public List<GameObject> pathNodes = new List<GameObject>();
   
    public List<List<GameObject>> links = new List<List<GameObject>>(); 


    void Start()
    {
        LinkNodes(pathNodes[0], pathNodes[4]);
        LinkNodes(pathNodes[0], pathNodes[2]);
        LinkNodes(pathNodes[0], pathNodes[5]);
        LinkNodes(pathNodes[0], pathNodes[7]);


    }

    void Update()
    {
        
    }

    private void OnDrawGizmos()
    {
        for (int i = 0; i < pathNodes.Count; i++)
        {
            Gizmos.DrawWireSphere(pathNodes[i].transform.position, 2);
        }

        for (int i = 0; i < links.Count - 1; i++)
        {
           // Gizmos.DrawLine(links[i]., pathNode[i + 1].transform.position);
        }
    }

    //private void LinkNode(GameObject a, GameObject b)
    //{
    //   // pathNode.Add(b);
    //   // pathNode.Add(a);
    //}

    //private void LinkNodelist(List<GameObject> nodesList)
    //{
    //    waypointsList.AddRange(nodesList);

    //}

    private void LinkNodes( GameObject a, GameObject b)
    {
        AddLink(new List<GameObject> { a, b});
        Debug.Log(links.Count);
    }


    private void AddLink(List<GameObject> nodes)
    {
        links.Add(nodes);
    }

}


//public class PathNodes
//{

//    public List<PathNodes> m_Links = new List<PathNodes>();


//    public void AddLink(PathNodes node)
//    {
//        m_Links.Add(node);
//    }
//}

//public class Nodes
//{
//    public GameObject parent;
//    public List<Child> children;
//}

//public class Child
//{
//    public enum Direction
//    { 
//    }

//    public Direction direction;
//    public GameObject childObject;
//}
