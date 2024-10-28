using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BossHealthService : IBossHealthService
{

    [Inject] public BossHealthSO bossHealthSO;


    public void DamageBoss(float amount)
    {
        bossHealthSO.currentHealth -= amount;
        bossHealthSO.currentHealth = Mathf.Clamp(bossHealthSO.currentHealth, 0f, bossHealthSO.maxHealth);
    }

    public void Start()
    {
        bossHealthSO.currentHealth = bossHealthSO.maxHealth;

    }
}
