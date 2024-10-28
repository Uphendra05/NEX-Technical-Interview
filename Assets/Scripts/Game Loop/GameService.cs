using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;


public class GameService : MonoBehaviour
{

    [Inject] private CameraSO cameraSO;
    [Inject] private PlayerHealthSO healthSO;
    [Inject] private BossHealthSO bossHealthSO;

    public PlayerController m_PlayerController;
    private DiContainer m_Container;
    public GameObject boosGameobject;
    public GameObject levelGameobject;
    public GameObject cameraGameobject;
    public GameObject gameOverPanel; 
    public GameObject gameWinPanel;
    public GameObject boss;
    public GameObject healthImage; 
    public GameObject bossHealthImage;
    public GameObject lasers;
    public AudioSource enragedAudio;

    [Inject]
    private void Construct(DiContainer container)
    {
        m_Container = container;
    }
    private void Awake()
    {
        m_PlayerController = m_Container.InstantiatePrefabForComponent<PlayerController>(cameraSO.player);
        cameraSO.target = m_PlayerController.gameObject;
        m_PlayerController.playerCam = cameraGameobject.GetComponent<Camera>();
        gameOverPanel.SetActive(false);
        Time.timeScale = 1;
        healthImage.SetActive(true);


    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        GameOver();
    }

    void GameOver()
    {
       if (healthSO.currentHealth <= 0)
       {
            enragedAudio.enabled = false;
            gameOverPanel.SetActive(true);
            healthImage.SetActive(false);
            m_PlayerController.gameObject.SetActive(false);
            Time.timeScale = 0;

        }

        if (bossHealthSO.currentHealth <= 0)
       {
            enragedAudio.enabled = false;
            gameWinPanel.SetActive(true);
            boss.SetActive(false);
            bossHealthImage.SetActive(false);
            m_PlayerController.gameObject.SetActive(false);
            lasers.SetActive(false);
            Time.timeScale = 0;
        }
    }
}
