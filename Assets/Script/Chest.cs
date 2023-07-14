using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Chest : MonoBehaviour
{
    public Text score;
    public int chestPoint = 0;

    public int totalPoint;

    public String nextScene;

    public int levelToUnlock;
    int numberOfUnlockedLevel;

    // Start is called before the first frame update
    void Start()
    {
        score.text = chestPoint.ToString() + "/" + totalPoint.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "chest")
        {
            Debug.Log("collect");
            chestPoint = chestPoint + 1;
            score.text = chestPoint.ToString() + "/" + totalPoint.ToString();
            collision.gameObject.SetActive(false);
        }

        if (collision.tag == "doors")
        {
            if (chestPoint == totalPoint)
            {
                numberOfUnlockedLevel = PlayerPrefs.GetInt("levelsUnlocked");
                
                if(numberOfUnlockedLevel <= levelToUnlock)
                {
                    PlayerPrefs.SetInt("levelsUnlocked", numberOfUnlockedLevel + 1);
                    SceneManager.LoadScene(nextScene);
                }
            }
        }
    }
}