using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "BossHealthScriptableObject", menuName = "ScriptableObjects/BossHealthScriptableObject")]

public class BossHealthSO : ScriptableObject
{
    public float maxHealth = 1500;
    public float currentHealth;


}
