using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{
    public void loadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void quitGame()
    {
        Debug.Log("Quitting game!");
        Application.Quit();
    }
}
