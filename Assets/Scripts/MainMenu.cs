using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   public void PlayGame()
    {
        SceneManager.LoadSceneAsync(7);
    }

    public void Options()
    {
        SceneManager.LoadSceneAsync(4);
    }

    public void QuitGame()
    {
        Application.Quit();
    }


    public void Credits()
    {
        SceneManager.LoadSceneAsync(8);
    }

    public void Lame()
    {
        SceneManager.LoadSceneAsync(9);
    }

}
