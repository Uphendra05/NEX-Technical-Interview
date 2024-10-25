using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using Zenject;
using Zenject.SpaceFighter;

public class BossMoveState : BaseBossState
{
    public override void Start()
    {

        m_BossView.bossSO.pathfinding = new FindPath(m_BossView.bossSO.startNode, m_BossView.bossSO.endNode);
        m_BossView.bossSO.currentPath = m_BossView.bossSO.pathfinding.FindBFSPath();

    }
    public override void Update() 
    { 
    
    
    }
    public override void FixedUpdate() 
    { 
    
    
    }
    public override void OnDestroy() 
    { 


    }

    private void Move()
    {
        if (m_BossView.bossSO.isEnraged == false)
        {


            if (m_BossView.bossSO.currentPath != null && m_BossView.bossSO.currentPath.Count > 0)
            {
                Debug.Log("IN Top");
                Vector3 targetPosition = m_BossView.bossSO.currentPath[m_BossView.bossSO.currentTargetIndex].position;
                targetPosition.y = m_BossView.transform.position.y;
                m_BossView.transform.position = Vector3.MoveTowards(m_BossView.transform.position, targetPosition, m_BossView.bossSO.speed * Time.deltaTime);
                m_BossView.transform.LookAt(new Vector3(m_BossView.bossSO.player.transform.position.x, m_BossView.transform.position.y, m_BossView.bossSO.player.transform.position.z));



                if (Vector3.Distance(m_BossView.transform.position, targetPosition) < 0.1f)
                {
                    Debug.Log("IN Mid");
                    m_BossView.bossSO.currentTargetIndex++;

                    if (m_BossView.bossSO.currentTargetIndex >= m_BossView.bossSO.currentPath.Count)
                    {
                        Debug.Log("IN Low");
                        Node newStartNode = m_BossView.bossSO.currentPath[m_BossView.bossSO.currentTargetIndex - 1];
                        Node newEndNode = GetNewEndNode();


                        m_BossView.bossSO.pathfinding = new FindPath(newStartNode, newEndNode);
                        m_BossView.bossSO.currentPath = m_BossView.bossSO.pathfinding.FindBFSPath();
                        m_BossView.bossSO.currentTargetIndex = 0;
                    }


                }
            }
        }
    }

    private Node GetNewEndNode()
    {
        int randomNode = Random.Range(1, m_BossView.bossSO.nodes.Count - 1);

        return m_BossView.bossSO.nodes[randomNode];
    }


}
