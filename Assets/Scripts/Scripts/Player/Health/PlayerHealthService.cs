using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerHealthService : IPlayerHealthService
{
    [Inject] public PlayerHealthSO playerHealthSO;

    public event Action OnHeal = delegate { };
    public event Action OnDamage = delegate { };

    public void DamagePlayer()
    {
        throw new NotImplementedException();
    }

    public int GetHealth()
    {
        throw new NotImplementedException();
    }

    public void HealPlayer()
    {
        throw new NotImplementedException();
    }

    public bool IsNoLives()
    {
        throw new NotImplementedException();
    }

    public void SetHealth()
    {
        throw new NotImplementedException();
    }

    public void SetHealth(int health)
    {
        throw new NotImplementedException();
    }
}
