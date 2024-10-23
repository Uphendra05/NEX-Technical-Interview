using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "HealthScriptableObject", menuName = "ScriptableObjects/HealthScriptableObject")]

public class PlayerHealthSO : ScriptableObject
{
    public int healthAmount;
    public int damageAmount;
    public int maxHealth = 100; // Subject to change ?

}
