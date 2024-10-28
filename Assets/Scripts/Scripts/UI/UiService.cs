using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiService : IUiService
{

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Debug.Log("Game Starting !");
    }

    public void GameOptions()
    {
        Debug.Log("Game Options !");

    }

    public void ExitGame()
    {
       Application.Quit();



    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);

        Debug.Log("Game MainMenu !");

    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
}
