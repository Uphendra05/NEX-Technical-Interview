using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerHealthView : MonoBehaviour
{
    private IPlayerHealthService m_HealthService;
    [Inject] PlayerHealthSO m_PlayerHealthSO;
    public RectTransform healthBar;
    private PlayerController playerhealth;
    public GameService gameservice;

    [Inject]
    private void Construct(IPlayerHealthService healthService)
    {
        m_HealthService = healthService;
    }

    private void OnEnable()
    {
        Actions.onHit += Damage;
        Actions.onHeal += Heal;
    }
    private void OnDisable()
    {
        StopAllCoroutines();
        Actions.onHit -= Damage;
        Actions.onHeal -= Heal;
    }
    private void OnDestroy()
    {
        StopAllCoroutines();

        Actions.onHit -= Damage;
        Actions.onHeal -= Heal;
    }

    void Start()
    {
        playerhealth = gameservice.m_PlayerController;
        m_HealthService.Start();
        

    }

    void Update()
    {

    }

    public void Damage(float damage)
    {
        if(!playerhealth.isInvincible)
        {
            m_HealthService.DamagePlayer(damage);
            StartCoroutine(LerpHealthBar());
        }
       
        
            

    }

    public void  Heal(float heal)
    {
        m_HealthService.HealPlayer(heal);

       
        StartCoroutine(LerpHealthBar());

    }

    IEnumerator LerpHealthBar()
    {
        float healthBarFillAmount = m_PlayerHealthSO.currentHealth / m_PlayerHealthSO.maxHealth;

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
