using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject MainMenuPanel;
    public GameObject OptionsPanel;
    public GameObject StartPanel;
    public GameObject GameOptionsPanel;
    public GameObject ControlsPanel;

    #region open panels
    public void OpenStartPanel()
    {
        MainMenuPanel.SetActive(false);
        StartPanel.SetActive(true);
    }

    public void OpenOptionsPanel()
    {
        MainMenuPanel.SetActive(false);
        OptionsPanel.SetActive(true);
    }

    public void OpenGameOptionsPanel()
    {
        OptionsPanel.SetActive(false);
        GameOptionsPanel.SetActive(true);
    }

    public void OpenControlsPanel()
    {
        OptionsPanel.SetActive(false);
        ControlsPanel.SetActive(true);
    }
    #endregion

    #region back buttons
    public void GetBackFromOptionsPanel()
    {
        OptionsPanel.SetActive(false);
        MainMenuPanel.SetActive(true);
    }

    public void GetBackFromStartPanel()
    {
        StartPanel.SetActive(false);
        MainMenuPanel.SetActive(true);
    }

    public void GetBackFromGameOptions()
    {
        GameOptionsPanel.SetActive(false);
        OptionsPanel.SetActive(true);
    }

    public void GetBackFromControls()
    {
        ControlsPanel.SetActive(false);
        OptionsPanel.SetActive(true);
    }
    #endregion
    
    #region start and exit
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
#endregion
}
