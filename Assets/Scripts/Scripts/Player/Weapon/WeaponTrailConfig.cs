using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponTrailScriptableObject", menuName = "ScriptableObjects/WeaponTrailScriptableObject")]

public class WeaponTrailConfig : ScriptableObject
{
    public Material mat;
    public AnimationCurve animationCurve;
    public float duration;
    public float minVertexDistance = 0f;
    public Gradient color;

    public float missDistance = 0f;
    public float simulationSpeed = 0f;

    
}
