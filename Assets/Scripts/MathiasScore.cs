using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MathiasScore : MonoBehaviour
{
    public int score = 0;  
    public TMP_Text scoreText; 

    
    public void AddScore(int points)
    {
        score += points;
        UpdateScoreText();
    }

    
    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }
}

