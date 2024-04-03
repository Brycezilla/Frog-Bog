using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMainMenu : MonoBehaviour
{
    public void Back()
    {
        SceneManager.LoadSceneAsync(0);
    }

    public void Easy()
    {
        SceneManager.LoadSceneAsync(10);
    }

    public void Normal()
    {
        SceneManager.LoadSceneAsync(11);
    }

    public void Hard()
    {
        SceneManager.LoadSceneAsync(12);
    }
}
