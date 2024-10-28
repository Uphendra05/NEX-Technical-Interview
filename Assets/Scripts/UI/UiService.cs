using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiService : IUiService
{

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void GameOptions()
    {

    }

    public void ExitGame()
    {
       Application.Quit();



    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);


    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

   
}
