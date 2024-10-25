using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{

    public int health = 100;
    public int maxHealth = 100;
    public BossMovement boss;
    public BossShooting enragedMode;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            TakeDamage(10);
        }


        if(health <= 50)
        {
            //boss.isEnraged = true;
            enragedMode.isEnraged = true;
        }
    }

    public void TakeDamage(int amount)
    {
        if(health > 0)
        {
            health -= amount;
        }

    }
}
