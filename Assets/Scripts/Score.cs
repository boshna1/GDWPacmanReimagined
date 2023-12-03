using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Build.Player;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    int score = 50000;
    int HighScore;
    bool GamePlay = true;
    public Text scoretext;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GamePlay == true)
        {
            scoretext.text = score.ToString();
            score--;
        }
        scoretext.text = score.ToString();
        if (GamePlay == false)
        {
            if (HighScore < score)
            {
                HighScore = score;
            }
        }
    }

    public void setGameFalse()
    {
        GamePlay = false;
    }

    public void ButtonPressed()
    {
        score -= 1000;
    }

    public void Escaped()
    {
        score -= 5000;
    }

    public void ResetGame()
    {
        score = 50000;
        GamePlay = true;
    }
}