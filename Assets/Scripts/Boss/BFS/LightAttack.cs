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
    public AudioSource bulletSound;
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
            bulletSound.pitch = Random.Range(1.0f, 1.7f);
            bulletSound.Play();
        }
        else
        {
            timer -= Time.deltaTime;
        }


      

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
