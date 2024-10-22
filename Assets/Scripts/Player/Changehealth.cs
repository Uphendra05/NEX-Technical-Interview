using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Changehealth : MonoBehaviour
{

    public float healTimer;
    public float DamageTimer;

    public bool playerIn;
    public enum Modifiers
    {
        Heal,
        Damage
    }

    public Modifiers modifier;
    private void Start()
    {
       
    }
    private void Update()
    {

        if(playerIn)
        {
            

           
            if (modifier == Modifiers.Heal)
            {
                if(healTimer <= 0)
                {
                    Actions.onHeal(100f);
                    healTimer = 1.5f;
                }
                else
                {
                    healTimer -= Time.deltaTime;
                }
            }

            if (modifier == Modifiers.Damage)
            {
                if (DamageTimer <= 0)
                {
                    Actions.onHit(175f);
                    DamageTimer = 1.5f;
                }
                else
                {
                    DamageTimer -= Time.deltaTime;
                }
               
            }
        }
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            playerIn = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerIn = false;

            healTimer = 0;
            DamageTimer = 0;

        }
    }


}
