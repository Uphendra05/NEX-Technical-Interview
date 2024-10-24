using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointGizmo : MonoBehaviour
{

    public List<GameObject> waypoints= new List<GameObject>();

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnDrawGizmos()
    {
        for (int i = 0; i < waypoints.Count; i++)
        {
            Gizmos.DrawWireSphere(waypoints[i].transform.position, 2);
        }
    }
}
