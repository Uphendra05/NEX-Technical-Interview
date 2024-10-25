using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShooting : MonoBehaviour
{
    public List<GameObject> firePoints  = new List<GameObject>();
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(firePoints[0].transform.position, firePoints[0].transform.forward);

        foreach (GameObject go in firePoints)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(go.transform.position, 1);
        }
        
    }
}
