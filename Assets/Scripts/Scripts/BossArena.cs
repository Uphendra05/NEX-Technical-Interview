using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossArena : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player Entered");
        }
    }
}
