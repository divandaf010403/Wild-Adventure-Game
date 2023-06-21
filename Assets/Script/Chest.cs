using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Chest : MonoBehaviour
{
    public Text score;
    public int chestPoint = 0;

    // Start is called before the first frame update
    void Start()
    {
        score.text = chestPoint.ToString() + "/5";
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
            score.text = chestPoint.ToString() + "/5";
            collision.gameObject.SetActive(false);
        }

        if (collision.tag == "doors")
        {
            if (chestPoint == 5)
            {
                SceneManager.LoadScene("Level2");
            }
        }
    }
}