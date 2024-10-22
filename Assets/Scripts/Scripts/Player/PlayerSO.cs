using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "PlayerScriptableObject", menuName = "ScriptableObjects/PlayerObject")]
public class PlayerSO : ScriptableObject
{
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody rb;
}
