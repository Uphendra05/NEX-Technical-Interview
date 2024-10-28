using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossArena : MonoBehaviour
{
    public GameObject boss;
    public GameObject bossHealthCanvas;
    public GameObject arenaDoor;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player Entered");
            boss.SetActive(true);
            bossHealthCanvas.SetActive(true);
            arenaDoor.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}
