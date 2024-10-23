using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponScriptableObject", menuName = "ScriptableObjects/WeaponScriptableObject")]

public class WeaponSO : ScriptableObject
{

    public Transform firePoint;
    
    public WeaponShootConfig weaponShootConfig;
    public WeaponTrailConfig weaponTrailConfig;

    public bool isReload;

    public int bulletCount;
    public int maxBullets;





}
