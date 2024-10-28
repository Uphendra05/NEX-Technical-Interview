using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Pool;
using Zenject;


public class WeaponService : MonoBehaviour
{
   
    public List<GameObject> firePoints = new List<GameObject>();

    public int damage = 10;
    public int range = 100;

    public BulletPool bulletPool;
    public GameObject bulletPrefab;
    public float bulletSpeed = 20f;

   
    private void Awake()
    {
        bulletPool = new BulletPool();
        bulletPool.bulletPrefab = bulletPrefab;
        bulletPool.bulletParent = null;

        bulletPool.Awake();
    }
    private void Start()
    {
        

    }
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
           Shoot();
        }
    }

    public void Shoot()
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



    private void OnDrawGizmos()
    {
        
      
    }


    /*
    public void Spawn(Transform parent)
    {
        weaponSO.lastShootTime = 0;
        trailRendererPool = new ObjectPool<TrailRenderer>(CreateTrail);

        weaponSO.model = Object.Instantiate(weaponSO.weaponObject);
        weaponSO.model.transform.SetParent(parent, false);
        weaponSO.model.transform.localPosition = weaponSO.spawnPoint;
        weaponSO.model.transform.localRotation = Quaternion.Euler(weaponSO.spawnRotation);

        weaponSO.shootFx = weaponSO.model.GetComponent<ParticleSystem>();


    }

    void Shoot()
    {
       // weaponScriptableObject.con
        Debug.Log("Shooting");

        if (Time.time > weaponSO.weaponShootConfig.fireRate + weaponSO.lastShootTime)
        {
            weaponSO.lastShootTime = Time.time;
            weaponSO.shootFx.Play();
            Vector3 shootDirection = weaponSO.shootFx.transform.forward;
            shootDirection.Normalize();

            if(Physics.Raycast(weaponSO.shootFx.transform.position,shootDirection,out RaycastHit hit,
                float.MaxValue, weaponSO.weaponShootConfig.whatIsEnemy))
            {
                PlayTrail(weaponSO.shootFx.transform.position, hit.point, hit);
            }

        }


    }

    public void PlayTrail(Vector3 startPoint, Vector3 endPoint, RaycastHit hit)
    {
        TrailRenderer instance = trailRendererPool.Get();
        instance.gameObject.SetActive(true);
        instance.transform.position = startPoint;
       

        instance.emitting = true;

        float distance = Vector3.Distance(startPoint, endPoint);
        float remainingDistance = distance;
        while (remainingDistance > 0)
        {
            instance.transform.position = Vector3.Lerp(startPoint,endPoint,Mathf.Clamp01(1- remainingDistance /distance));
            remainingDistance -= weaponSO.weaponTrailConfig.simulationSpeed * Time.deltaTime;
            
        }
        instance.transform.position = endPoint;

        if(hit.collider != null)
        {
            Debug.Log(hit.transform.name);
        }

       
        instance.emitting = false;
        instance.gameObject.SetActive(false);
        trailRendererPool.Release(instance);

    }

    private TrailRenderer CreateTrail()
    {
        GameObject instance = new GameObject("Bullet Trail");
        TrailRenderer trail = instance.AddComponent<TrailRenderer>();
        trail.colorGradient = weaponSO.weaponTrailConfig.color;
        trail.material = weaponSO.weaponTrailConfig.mat;
        trail.widthCurve = weaponSO.weaponTrailConfig.animationCurve;
        trail.time = weaponSO.weaponTrailConfig.duration;
        trail.minVertexDistance = weaponSO.weaponTrailConfig.minVertexDistance;

        trail.emitting = false;
        trail.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;

        return trail;

    }
    */
}
