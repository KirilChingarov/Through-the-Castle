using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void loadGame()
    {
        SceneManager.LoadScene(2);
    }

    public void quitGame()
    {
        Debug.Log("Quitting game!");
        Application.Quit();
    }

    public void howToPlayMenu()
    {
        SceneManager.LoadScene(1);
    }

    public void backButton()
    {
        SceneManager.LoadScene(0);
    }
}
