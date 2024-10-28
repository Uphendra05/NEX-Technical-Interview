using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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
            if (bulletParent != null)
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