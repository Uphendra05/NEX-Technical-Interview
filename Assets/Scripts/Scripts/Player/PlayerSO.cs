using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "PlayerScriptableObject", menuName = "ScriptableObjects/PlayerScriptableObject")]

public class PlayerSO : ScriptableObject
{
    public float speed;
    public Rigidbody rb;
    public LayerMask whatisGround;
    public LayerMask rayGround;
}
