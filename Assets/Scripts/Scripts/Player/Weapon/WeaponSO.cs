using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponScriptableObject", menuName = "ScriptableObjects/WeaponScriptableObject")]

public class WeaponSO : ScriptableObject
{

    public EWeaponType weaponType;
    public string weaponName;
    public GameObject weaponObject;
    public Vector3 spawnPoint;
    public Vector3 spawnRotation;


    public WeaponShootConfig weaponShootConfig;
    public WeaponTrailConfig weaponTrailConfig;

    public bool isReload;

    public int bulletCount;
    public int maxBullets;
    public GameObject model;
    public float lastShootTime;
    public ParticleSystem shootFx;





}
