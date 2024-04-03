using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    //public static int SceneNumber;
    void Start()
    {
        StartCoroutine(ToMainMenu());
        
    }

    IEnumerator ToMainMenu()
    {
        yield return new WaitForSeconds(175);
        SceneManager.LoadScene(3);
    }
}
