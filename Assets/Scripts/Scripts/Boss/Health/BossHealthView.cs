using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BossHealthView : MonoBehaviour
{
    private IBossHealthService m_HealthService;
    [Inject] BossHealthSO m_BossHealthSO;
    public RectTransform healthBar;
    public BossShooting bossHealth;

    [Inject]
    private void Construct(IBossHealthService healthService)
    {
        m_HealthService = healthService;
    }

    private void OnEnable()
    {
        Actions.onBossHit += Damage;
       
    }
    private void OnDisable()
    {
        StopAllCoroutines();
        Actions.onBossHit -= Damage;
        
    }
    private void OnDestroy()
    {
        StopAllCoroutines();

        Actions.onBossHit -= Damage;
       
    }

    void Start()
    {
        m_HealthService.Start();


    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P)) 
        {
            Actions.onBossHit(15);
        }

        if(m_BossHealthSO.currentHealth <= 50)
        {
            bossHealth.isEnraged = true;
           

        }

    }

    public void Damage(float damage)
    {

        m_HealthService.DamageBoss(damage);
        StartCoroutine(LerpHealthBar());



    }

    IEnumerator LerpHealthBar()
    {
        float healthBarFillAmount = m_BossHealthSO.currentHealth / m_BossHealthSO.maxHealth;

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
