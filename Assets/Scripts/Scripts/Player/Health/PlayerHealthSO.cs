using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "PlayerHealthScriptableObject", menuName = "ScriptableObjects/PlayerHealthScriptableObject")]

public class PlayerHealthSO : ScriptableObject
{
   
    public float maxHealth = 100; 
    public float currentHealth;

}
