using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerHealthService : IPlayerHealthService
{
    [Inject] public PlayerHealthSO playerHealthSO;

    private DiContainer DiContainer;

    private PlayerHealthView playerHealthView;
    private RectTransform healthBar;


    [Inject]
    private void Construct(DiContainer container)
    {
        DiContainer = container;
    }

    public void Start()
    {
        playerHealthSO.currentHealth = playerHealthSO.maxHealth;
       
    }

    public void DamagePlayer(float amount)
    {

        playerHealthSO.currentHealth -= amount;
        playerHealthSO.currentHealth = Mathf.Clamp(playerHealthSO.currentHealth, 0f, playerHealthSO.maxHealth);


    }

    public void HealPlayer(float amount)
    {
        playerHealthSO.currentHealth += amount;
        playerHealthSO.currentHealth = Mathf.Clamp(playerHealthSO.currentHealth, 0f, playerHealthSO.maxHealth);


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

    public int GetHealth()
    {
        throw new NotImplementedException();
    }


  

   
}
