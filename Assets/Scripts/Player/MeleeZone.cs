using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Enemy in Zone");
            Destroy(other.gameObject);
        }
    }
}
