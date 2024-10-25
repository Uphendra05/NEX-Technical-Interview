using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShooting : MonoBehaviour
{
    public List<GameObject> firePoints  = new List<GameObject>();
    private List<LineRenderer> lineRenderers = new List<LineRenderer>();

    public bool isEnraged;
    public float timer = 10;
    void Start()
    {
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

        if(isEnraged)
        {
            if(timer <=0)
            {
                Debug.Log("Boss Cooldown in progress");
                isEnraged = false;
                this.gameObject.SetActive(false);
            }
            else
            {
                DeployLasers();
                transform.Rotate(0, 100 * Time.deltaTime, 0);
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

                LineRenderer lr = lineRenderers[i]; // Get the corresponding LineRenderer
                lr.SetPosition(0, position); // Set the line's start position

                RaycastHit hit;
                if (Physics.Raycast(position, direction, out hit, 100))
                {
                    // Ray hit something
                    lr.SetPosition(1, hit.point); // Set the line's end position to the hit point
                    lr.startColor = Color.red;
                    lr.endColor = Color.red;
                }
                else
                {
                    // Ray did not hit anything
                    Vector3 endPosition = position + direction * 100;
                    lr.SetPosition(1, endPosition); // Set the line's end position to the max distance
                    lr.startColor = Color.red;
                    lr.endColor = Color.red;
                }
            }
        }
    }
}

