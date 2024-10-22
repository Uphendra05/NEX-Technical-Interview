using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "PlayerScriptableObject", menuName = "ScriptableObjects/PlayerScriptableObject")]

public class PlayerSO : ScriptableObject
{
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody rb;
}
