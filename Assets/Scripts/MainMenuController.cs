using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public GameObject optionsPanel;

    private void Start()
    {
        // Ensure the Main Menu panel is initially active, and the Options panel is inactive.
        mainMenuPanel.SetActive(true);
        optionsPanel.SetActive(false);
    }

    public void ToggleOptionsPanel()
    {
        mainMenuPanel.SetActive(!mainMenuPanel.activeSelf);
        optionsPanel.SetActive(!optionsPanel.activeSelf);
    }
}
