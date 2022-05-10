using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayLevel1()
    {
        SceneManager.LoadScene("Scenes/Level1");
    }

    public void PlayPlayground()
    {
        SceneManager.LoadScene("Scenes/Playground");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
