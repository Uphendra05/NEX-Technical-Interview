using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Vector3 position;
    public List<Node> neighbors = new List<Node>();


    private void Start()
    {
        position = transform.position;
    }

    void OnDrawGizmos()
    {

       Gizmos.DrawWireSphere(transform.position, 2);


        Gizmos.color = Color.green;
        foreach (var neighbor in neighbors)
        {
            Gizmos.DrawLine(transform.position, neighbor.transform.position);
        }
    }
}
