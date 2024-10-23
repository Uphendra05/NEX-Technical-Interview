using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Pool;
using Zenject;


public class WeaponService : MonoBehaviour
{
    public WeaponSO weaponSO;

    private ObjectPool<TrailRenderer> trailRendererPool;

    private void Start()
    {
        Spawn(this.transform);

    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.H))
        {
           Shoot();
        }
    }

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
}
