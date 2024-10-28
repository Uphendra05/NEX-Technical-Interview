using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class GameService : MonoBehaviour
{

    [Inject] private CameraSO cameraSO;
    [Inject] private PlayerHealthSO healthSO;

    public PlayerController m_PlayerController;
    private DiContainer m_Container;
    public GameObject boosGameobject;
    public GameObject levelGameobject;
    public GameObject cameraGameobject;
    public GameObject gameOverPanel; 
    public GameObject healthImage; 

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
        if(Input.GetKeyDown(KeyCode.F1))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        GameOver();
    }

    void GameOver()
    {
       if (healthSO.currentHealth <= 0)
       {

            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
            healthImage.SetActive(false);
            m_PlayerController.gameObject.SetActive(false);
       }
    }
}
