using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "RaycastScriptableObject", menuName = "ScriptableObjects/RaycastScriptableObject")]

public class RaycastSO : ScriptableObject
{
    public Camera cam;
    public LayerMask rayGround;

}
