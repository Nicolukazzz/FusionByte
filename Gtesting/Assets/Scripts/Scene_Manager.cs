using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Manager : MonoBehaviour
{
    public void GameStart()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

    public void optionsButton()
    {
        SceneManager.LoadScene(3, LoadSceneMode.Single);
    }

    public void exitButton()
    {
        Application.Quit();
    }

    public void startButton() 
    {

    }

    public void levelsButton()
    {
        SceneManager.LoadScene(2, LoadSceneMode.Single);
    }

    public void backButton()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }
}
