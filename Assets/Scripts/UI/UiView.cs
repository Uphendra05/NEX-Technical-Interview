using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class UiView : MonoBehaviour
{
    private IUiService m_UiService;

    public AudioSource m_AudioSource;
    public GameObject mainPanel;
    public bool isLoad;

    [Inject]
    private void Construct(IUiService uiService)
    {
        m_UiService = uiService;
    }

    void Start()
    {

    }


    void Update()
    {
       
    }

    public void StartGame()
    {

        m_UiService.StartGame();
    }
    public void GameOptions()
    {
        m_UiService.GameOptions();
    }
    public void EndGame()
    {
        m_UiService.ExitGame();
    }
    public void MainMenu()
    {
        m_UiService.MainMenu();
    }

    public void RestartGame()
    {
        m_UiService.RestartGame();
    }

    public void PlayClickSound()
    {
        m_AudioSource.Play();
    }
    public void Back()
    {
        mainPanel.SetActive(true);
    }

   
}
