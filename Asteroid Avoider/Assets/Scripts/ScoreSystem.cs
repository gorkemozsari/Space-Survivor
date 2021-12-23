using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private float scoreMultiplier;
    public const string HighScoreKey = "HighScore";
    
    private bool shouldCount = true;
    private float score;
    void Update()
    {
        if(!shouldCount) {return;}
        
        score += Time.deltaTime * scoreMultiplier;

        scoreText.text = Mathf.FloorToInt(score).ToString();
    }

    public void startTimer()
    {
        shouldCount = true;
    }
    public int EndTimer()
    {
        shouldCount = false;
        scoreText.text = string.Empty;
        int currentHighScore = PlayerPrefs.GetInt(HighScoreKey, 0);
        if(score > currentHighScore)
        {
           PlayerPrefs.SetInt(HighScoreKey, Mathf.FloorToInt(score));
        }
        return Mathf.FloorToInt(score);
    }

}
