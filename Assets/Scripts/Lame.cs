using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lame : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(ToMainMenu());

    }

    IEnumerator ToMainMenu()
    {
        yield return new WaitForSeconds(48);
        SceneManager.LoadScene(3);
    }
}
