using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;



public interface IPlayerHealthService
{


    public abstract void Start();
    public abstract void HealPlayer(float amount);
    public abstract void DamagePlayer(float amount);

    public abstract void SetHealth();
    public abstract void SetHealth(int health);
    public abstract int GetHealth();

    public abstract bool IsNoLives();


     
}