using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BossShooting : MonoBehaviour
{
    public List<GameObject> firePoints  = new List<GameObject>();
    private List<LineRenderer> lineRenderers = new List<LineRenderer>();

    public bool isEnraged;
    public float timer = 17;
    public GameObject lightAttack;
    public BossMovement boss;

    public AudioSource laserSound;
    void Start()
    {
        timer = 17.0f;

        foreach (GameObject obj in firePoints)
        {
            LineRenderer lr = obj.AddComponent<LineRenderer>();
            lr.startWidth = 0.75f;
            lr.endWidth = 0.75f;
            lr.positionCount = 2;  // Two points for the line: start and end

            lr.material = new Material(Shader.Find("Sprites/Default")); // Use a simple shader
            lineRenderers.Add(lr);
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (isEnraged)
        {
           

            lightAttack.SetActive(false);
            boss.speed = 0;

            if (timer <=0)
            {
                isEnraged = false;
                this.gameObject.SetActive(false);
                lightAttack.SetActive(true);
                boss.speed = 20;
                laserSound.enabled = false;
            }
            else
            {
               this.transform.parent = null;

                DeployLasers();
                
                transform.Rotate(0, 45 * Time.deltaTime, 0);
                timer -= Time.deltaTime;
                


            }
        }
       


    }



    private void DeployLasers()
    {

        if (firePoints == null || firePoints.Count == 0) return;

        for (int i = 0; i < firePoints.Count; i++)
        {
            
            GameObject obj = firePoints[i];
            if (obj != null)
            {
                Vector3 position = obj.transform.position;
                Vector3 direction = obj.transform.forward;

                LineRenderer lr = lineRenderers[i];
                lr.SetPosition(0, position);

                int bulletLayer = LayerMask.NameToLayer("Bullet");
                int raycastLayerMask = ~(1 << bulletLayer);
                RaycastHit hit;
                if (Physics.Raycast(position, direction, out hit, 100, raycastLayerMask))
                {
                    if(hit.collider.gameObject.CompareTag("Player"))
                    {
                        Actions.onHit(0.95f);
                    }
                    
                    lr.SetPosition(1, hit.point); 
                    lr.startColor = Color.red;
                    lr.endColor = Color.red;
                   
                }
                else
                {
                    Vector3 endPosition = position + direction * 100;
                    lr.SetPosition(1, endPosition); 
                    lr.startColor = Color.red;
                    lr.endColor = Color.red;
                }
            }
        }
    }
}

