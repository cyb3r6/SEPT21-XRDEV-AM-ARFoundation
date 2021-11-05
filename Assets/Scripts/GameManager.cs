using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int lives = 10;
    public Text livesText;

    void Awake()
    {
        instance = this;
    }

    public void LoseLives()
    {
        // decreases lives by 1
        lives--;

        livesText.text = lives.ToString();

        if (lives <= 0)
        {
            // Gameover! Pause game or something
        }
    }
   
}
