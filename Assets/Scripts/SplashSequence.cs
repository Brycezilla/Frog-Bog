using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashSequence : MonoBehaviour
{
    public static int SceneNumber;
    FadeInOut fade;
    void Start()
    {

        fade = FindObjectOfType<FadeInOut>();
        if (SceneNumber == 0)
        {
            StartCoroutine (ToSplashTwo());
        }
        if (SceneNumber == 1)
        {
            StartCoroutine(ToSplashThree());
        }
        if (SceneNumber == 2)
        {
            StartCoroutine(ToMainMenu());
        }
    }
    IEnumerator ToSplashTwo()
    {
       // fade.FadeIn();
        yield return new WaitForSeconds(3);
        SceneNumber = 1;
        fade.FadeIn();
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(1);
    }

    IEnumerator ToSplashThree()
    {
        fade.FadeOut();
        yield return new WaitForSeconds(3);
        SceneNumber = 2;
        fade.FadeIn();
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(2);
    }
    IEnumerator ToMainMenu()
    {
        fade.FadeOut();
        yield return new WaitForSeconds(3);
        SceneNumber = 3;
        fade.FadeIn();
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(3);
    }

}
