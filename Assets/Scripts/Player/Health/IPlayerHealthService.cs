using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;



public interface IPlayerHealthService
{


    public abstract void Start();
    public abstract void HealPlayer(float amount);
    public abstract void DamagePlayer(float amount);

    


     
}