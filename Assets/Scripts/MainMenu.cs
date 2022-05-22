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

    public void PlayLevel2()
    {
        SceneManager.LoadScene("Scenes/Level2");
    }

    public void PlayLevel3()
    {
        SceneManager.LoadScene("Scenes/Level3");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
