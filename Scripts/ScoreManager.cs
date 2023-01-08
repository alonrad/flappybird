using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreManager : MonoBehaviour
{

    public static int currentScore;
    public static int highScore;
    
    [SerializeField] private TextMeshProUGUI scoreText;

    void Awake()
    {
        currentScore = 0;
        highScore = PlayerPrefs.GetInt("HighScore");
    }

    void Update()
    {
        if (scoreText) {
            scoreText.text = currentScore.ToString();
        }
        
        if (highScore < currentScore)
        {
            highScore = currentScore;
            PlayerPrefs.SetInt("HighScore", highScore);
        }
    }

    public static void Score()
    {
        currentScore++;
    }
}
