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

    public float dashDistance = 5f;
    public float dashTime = 0.5f;
    public float dashCooldown = 2f;
    public bool canDash = true;
    public float obstacleCheckDistance = 1f;
}
