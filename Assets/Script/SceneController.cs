using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void StartGame(GameObject LevelSelect)
    {
        LevelSelect.SetActive(true);
        LevelSelect.transform.localPosition = new Vector3(0, -100, 0); 
        GameObject.Find("MainMenuPanel").SetActive(false);
    }

    public void CloseLevelPanel(GameObject MainMenuPanel)
    {
        MainMenuPanel.SetActive(true);
        MainMenuPanel.transform.localPosition = new Vector3(0, -100, 0);
        GameObject.Find("LevelSelect").SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Exit Game");
    }

    public void OpenLevel(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }

    public void CreditPanelOpen(GameObject credits)
    {
        credits.SetActive(true);
        credits.transform.localPosition = new Vector3(0, 0, 0);
    }

    public void CreditPanelClose(GameObject credits)
    {
        credits.SetActive(false);
    }

    public void resetLevel()
    {
        PlayerPrefs.SetInt("levelsUnlocked", 1);
        PlayerPrefs.DeleteAll();
    }
}
