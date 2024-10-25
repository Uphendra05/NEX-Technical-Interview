using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightAttack : MonoBehaviour
{
    public List<GameObject> firePoints = new List<GameObject>();

    public GameObject bulletPrefab;
    public float bulletSpeed = 20f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            SpawnBullets();
        }

    }

    private void OnDrawGizmos()
    {
        //foreach (GameObject go in firePoints)
        //{
        //    Gizmos.color = Color.yellow;
        //    Gizmos.DrawWireSphere(go.transform.position, 0.75f);
        //    Gizmos.color = Color.red;

        //    Gizmos.DrawLine(go.transform.position, go.transform.position + go.transform.forward * 100);
        //}
    }


    public void SpawnBullets()
    {
        foreach (GameObject firepoint in firePoints)
        {
            if (firepoint != null)
            {
                // Instantiate the bullet at the firepoint's position and rotation
                GameObject bullet = Instantiate(bulletPrefab, firepoint.transform.position , firepoint.transform.rotation);

                // Apply velocity to make it move forward
                Rigidbody rb = bullet.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.velocity = firepoint.transform.forward * bulletSpeed;
                }
            }
        }

    }
}
