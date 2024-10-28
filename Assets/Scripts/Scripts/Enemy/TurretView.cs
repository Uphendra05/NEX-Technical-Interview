using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class TurretView : MonoBehaviour
{
   
    private ITurretService m_TurretService;
    public GameService Service;
    [Inject] private TurretSO turretSO;

    public List<GameObject> firePoints = new List<GameObject>();

   

    public BulletPool bulletPool;
    public GameObject bulletPrefab;
    public float bulletSpeed = 20f;
    public float timer;

    [Inject]
    private void Construct(ITurretService turretService)
    {
        m_TurretService = turretService;
    }

    private void Awake()
    {
        bulletPool = new BulletPool();
        bulletPool.bulletPrefab = bulletPrefab;
        bulletPool.bulletParent = null;

        bulletPool.Awake();
    }
    void Start()
    {
        turretSO.target = Service.m_PlayerController.gameObject;

        m_TurretService.Start(this);
    }

    
    void Update()
    {
        m_TurretService.Update();


        if (timer <= 0)
        {
            timer = 1.5f;
            Shoot();

        }
        else
        {
            timer -= Time.deltaTime;
        }
    }

    void Shoot()
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
