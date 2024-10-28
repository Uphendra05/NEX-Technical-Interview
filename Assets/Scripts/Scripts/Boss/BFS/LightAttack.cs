using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightAttack : MonoBehaviour
{
    public List<GameObject> firePoints = new List<GameObject>();
    public BulletPool bulletPool;
    public GameObject bulletPrefab;
    public GameObject bulletParentTransform;
    public float bulletSpeed = 20f;

    public float timer = 0;

    private void Awake()
    {
        bulletPool = new BulletPool();
        bulletPool.bulletPrefab = bulletPrefab;
        bulletPool.bulletParent = bulletParentTransform;

        bulletPool.Awake();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (timer <= 0)
        {
            timer = 1.5f;
            SpawnBullets();

        }
        else
        {
            timer -= Time.deltaTime;
        }




        //if (Input.GetKeyDown(KeyCode.LeftControl))
        //{
        //    SpawnBullets();
        //}

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
                GameObject bullet = bulletPool.GetBullet();

                bullet.transform.position = firepoint.transform.position;
                bullet.transform.rotation = firepoint.transform.rotation;

                Rigidbody rb = bullet.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.velocity = firepoint.transform.forward * bulletSpeed;
                }

                StartCoroutine(ReturnBulletToPoolAfterDelay(bullet, 2f));
            }
        }

    }

    private IEnumerator ReturnBulletToPoolAfterDelay(GameObject bullet, float delay)
    {
        yield return new WaitForSeconds(delay);
        bulletPool.ReturnBullet(bullet);
    }


}


public class BulletPool 
{
    public GameObject bulletPrefab;
    public GameObject bulletParent;     
    public int poolSize = 20;           
    private Queue<GameObject> bulletPool;

    public void Awake()
    {
        bulletPool = new Queue<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            if(bulletParent != null)
            {
                GameObject bullet = Object.Instantiate(bulletPrefab, bulletParent.transform);
                bullet.SetActive(false);
                bulletPool.Enqueue(bullet);
            }
            else
            {
                GameObject bullet = Object.Instantiate(bulletPrefab);
                bullet.SetActive(false);
                bulletPool.Enqueue(bullet);
            }
           
        }
    }

    public GameObject GetBullet()
    {
        if (bulletPool.Count > 0)
        {
            GameObject bullet = bulletPool.Dequeue();
            bullet.SetActive(true);
            return bullet;
        }
        else
        {
            GameObject bullet = Object.Instantiate(bulletPrefab); 
            bullet.SetActive(true);
            return bullet;
        }
    }

    public void ReturnBullet(GameObject bullet)
    {
        bullet.SetActive(false);
        bulletPool.Enqueue(bullet);
    }
}