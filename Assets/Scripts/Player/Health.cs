using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class Health : MonoBehaviour
{
    public float maxHealth ;  
    public float currentHealth;     
    public RectTransform healthBar;

    

    void Start()
    {
        currentHealth = maxHealth;  
       
    }
    private void OnEnable()
    {
        Actions.onHit += TakeDamage;
        Actions.onHeal += GainHealth;
    }
    private void OnDisable()
    {
        Actions.onHit -= TakeDamage;
        Actions.onHeal -= GainHealth;
    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.F1))
        //{
        //    Actions.onHit.Invoke(100f);
        //}
        if (Input.GetKeyDown(KeyCode.F2))
        {
            Actions.onHeal.Invoke(50f);
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;    
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth); 

        
        StartCoroutine(LerpHealthBar());
    }

    public void GainHealth(float amount)
    {
        currentHealth += amount;    
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth); 

        
        StartCoroutine(LerpHealthBar());
    }

    IEnumerator LerpHealthBar()
    {
        float healthBarFillAmount = currentHealth / maxHealth; 

        Vector3 initialScale = healthBar.localScale; 
        Vector3 targetScale = new Vector3(healthBarFillAmount, 1f, 1f); 

        float elapsedTime = 0f; 

        while (elapsedTime < 0.5f) 
        {
            elapsedTime += Time.deltaTime;

            float t = elapsedTime / 0.5f; 

           
            float lerpedScaleX = Mathf.Lerp(initialScale.x, targetScale.x, t);
            healthBar.localScale = new Vector3(lerpedScaleX, 1f, 1f);

            yield return null; 
        }
    }
}
