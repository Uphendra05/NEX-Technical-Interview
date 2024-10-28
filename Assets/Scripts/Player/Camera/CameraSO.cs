using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;


[CreateAssetMenu(fileName = "CameraScriptableObject", menuName = "ScriptableObjects/CameraScriptableObject")]

public class CameraSO : ScriptableObject
{
    public PlayerController player ;
    public float deadzone;
    public float followdistance;
    public GameObject target;
    public Vector3 camePos;
    public Vector3 followoffset;
    public Vector3 _mouseDir;
}
