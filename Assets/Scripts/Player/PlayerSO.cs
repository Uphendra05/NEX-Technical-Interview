using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "PlayerScriptableObject", menuName = "ScriptableObjects/PlayerScriptableObject")]

public class PlayerSO : ScriptableObject
{
    [Header("Player Attributes")]
    public float speed;
    public Rigidbody rb;
    public LayerMask whatIsRayGround;

    [Header("Player Dash Attributes ")]
    public float dashDistance = 5f;
    public float dashTime = 0.5f;
    public float dashCooldown = 2f;
    public bool canDash = true;
    public float obstacleCheckDistance = 1f;

    [Header("Player Shoot Attributes")]
    public Transform firePoint;
    public LayerMask whatIsEnemy;
    public float fireRate;

    [Header("Player Fall Attributes")]
    public float gravity;
    public Vector3 playerPos;
    public LayerMask whatisGround;
    public bool isGrounded = false;
    public Vector3 lastPos;
}
