using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    int score;
    int highScore;
    Text scoreText;
    public Text panelScore;
    public Text panelHighScore;
    public GameObject New;

    void Start()
    {
        score = 0;
        scoreText = GetComponent<Text>();
        scoreText.text = score.ToString();
        panelScore.text = score.ToString();

        highScore = PlayerPrefs.GetInt("highScore");
        panelHighScore.text = highScore.ToString();
        New.SetActive(false);
    }

    public void Scored()
    {
        score++;
        scoreText.text = score.ToString();
        panelScore.text = score.ToString();

        if(score > highScore)
        {
            highScore = score;
            panelHighScore.text = highScore.ToString();
            PlayerPrefs.SetInt("highScore", highScore);
            New.SetActive(true);
        }
    }

    public int GetScore()
    { 
        return score;
    }
}
