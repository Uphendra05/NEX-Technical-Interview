using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;


[CreateAssetMenu(fileName = "GameLoopScriptableObject", menuName = "ScriptableObjects/GameLoopScriptableObject")]

public class GameLoopSO : ScriptableObject
{
    public GameObject boosGameobjec;
    public GameObject levelGameobjec;
    public GameObject cameraGameobject;
}
