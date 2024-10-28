using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "TurretScriptableObject", menuName = "ScriptableObjects/TurretScriptableObject")]

public class TurretSO : ScriptableObject
{

    public GameObject bullet;
    public float playerDamage;
    public GameObject target;


}
