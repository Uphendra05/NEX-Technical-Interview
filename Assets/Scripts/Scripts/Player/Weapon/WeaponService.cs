using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Pool;
using Zenject;


public class WeaponService : MonoBehaviour
{
    //public WeaponSO weaponSO;

    //private ObjectPool<TrailRenderer> trailRendererPool;

    public int damage = 10;
    public int range = 100;

    public Transform spawnPoint;
    public TrailRenderer bulletTrail;
    public float shootDelay = 0.5f;
    public LayerMask whatIsEnemy ;
    private float lastShootTime;
    public bool isSpread;
    public Vector3 spreadAmount = Vector3.one;

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

        if(lastShootTime  + shootDelay < Time.time)
        {

            Vector3 direction = GetDirection();


            RaycastHit hitInfo;

            if (Physics.Raycast(spawnPoint.transform.position, direction, out hitInfo, range))
            {
                if(hitInfo.collider.gameObject.CompareTag("Enemy"))
                {
                    Destroy(hitInfo.collider.gameObject);

                }
                TrailRenderer trail = Instantiate(bulletTrail, spawnPoint.position, Quaternion.identity);
               
                StartCoroutine(MoveTrail(trail, hitInfo));
               
                lastShootTime = Time.time;
            }
        }
      

    }

    public IEnumerator MoveTrail(TrailRenderer trail, RaycastHit hit)
    {
        float time = 0;
        Vector3 startPos = trail.transform.position;

        while(time < 1)
        {
            bulletTrail.transform.position = Vector3.Lerp(startPos, hit.point, time);

            time += Time.deltaTime / trail.time ;

            yield return null;

        }

        trail.transform.position = hit.point;



        yield return null;
    }

    private Vector3 GetDirection()
    {
        Vector3 direction = spawnPoint.transform.forward;

        if(isSpread)
        {
            direction += new Vector3(
                Random.Range(-spreadAmount.x, spreadAmount.x),
                Random.Range(-spreadAmount.y, spreadAmount.y),
                Random.Range(-spreadAmount.z, spreadAmount.z));

            direction.Normalize();

        }

        return direction.normalized;

    }

    private void OnDrawGizmos()
    {
        
        Vector3 startPoint = spawnPoint.position;

        Vector3 direction = spawnPoint.forward;

        float rayLength = range;

        RaycastHit hit;
        if (Physics.Raycast(startPoint, direction, out hit, rayLength))
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(startPoint, hit.point);

            // Optionally, draw a sphere at the hit point
            Gizmos.DrawSphere(hit.point, 0.2f);
        }
        else
        {
            // If no hit, draw a red ray showing the full length
            Gizmos.color = Color.red;
            Gizmos.DrawLine(startPoint, startPoint + direction * rayLength);
        }
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
