
using UnityEngine;


public class BossMoveState : BaseBossState
{
    public override void Start()
    {

        m_BossView.bossData.pathfinding = new FindPath(m_BossView.bossData.startNode, m_BossView.bossData.endNode);
        m_BossView.bossData.currentPath = m_BossView.bossData.pathfinding.FindBFSPath();

    }
    public override void Update() 
    {

        Move();
    }
    public override void FixedUpdate() 
    { 
    
    
    }
    public override void OnDestroy() 
    { 


    }

    private void Move()
    {
        if (m_BossView.bossData.isEnraged == false)
        {


            if (m_BossView.bossData.currentPath != null && m_BossView.bossData.currentPath.Count > 0)
            {
                Vector3 targetPosition = m_BossView.bossData.currentPath[m_BossView.bossData.currentTargetIndex].position;
                targetPosition.y = m_BossView.transform.position.y;
                m_BossView.transform.position = Vector3.MoveTowards(m_BossView.transform.position, targetPosition, m_BossView.bossData.speed * Time.deltaTime);
                m_BossView.transform.LookAt(new Vector3(m_BossView.bossData.player.transform.position.x, m_BossView.transform.position.y, m_BossView.bossData.player.transform.position.z));



                if (Vector3.Distance(m_BossView.transform.position, targetPosition) < 0.1f)
                {
                    m_BossView.bossData.currentTargetIndex++;

                    if (m_BossView.bossData.currentTargetIndex >= m_BossView.bossData.currentPath.Count)
                    {
                        Node newStartNode = m_BossView.bossData.currentPath[m_BossView.bossData.currentTargetIndex - 1];
                        Node newEndNode = GetNewEndNode();


                        m_BossView.bossData.pathfinding = new FindPath(newStartNode, newEndNode);
                        m_BossView.bossData.currentPath = m_BossView.bossData.pathfinding.FindBFSPath();
                        m_BossView.bossData.currentTargetIndex = 0;
                    }


                }
            }
        }
    }

    private Node GetNewEndNode()
    {
        int randomNode = Random.Range(1, m_BossView.bossData.nodes.Count - 1);

        return m_BossView.bossData.nodes[randomNode];
    }


}
