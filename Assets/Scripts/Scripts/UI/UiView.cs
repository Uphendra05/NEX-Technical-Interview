using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class UiView : MonoBehaviour
{
    private IUiService m_UiService;


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
}
