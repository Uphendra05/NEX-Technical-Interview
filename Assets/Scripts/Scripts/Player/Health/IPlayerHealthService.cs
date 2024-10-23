using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;



public interface IPlayerHealthService
{
    public event Action OnHeal;
    public event Action OnDamage;
    public abstract void HealPlayer();
    public abstract void DamagePlayer();

    public abstract void SetHealth();
    public abstract void SetHealth(int health);
    public abstract int GetHealth();

    public abstract bool IsNoLives();
     
}