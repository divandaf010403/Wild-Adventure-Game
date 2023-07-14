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
}
