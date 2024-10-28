using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
       

        gameObject.SetActive(false);

        if (collision.gameObject.CompareTag("Player"))
        {
            Actions.onHit(25.0f);
           // Debug.Log("Player Hit !");
           gameObject.SetActive(false);
        }
    }
}
