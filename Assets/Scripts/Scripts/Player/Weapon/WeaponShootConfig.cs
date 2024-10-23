using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "WeaponShootScriptableObject", menuName = "ScriptableObjects/WeaponShootScriptableObject")]

public class WeaponShootConfig : ScriptableObject
{
    public LayerMask whatIsEnemy;
    public float fireRate;
    public Vector3 bulletSpread;
}
