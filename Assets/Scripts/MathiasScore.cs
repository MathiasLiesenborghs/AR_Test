using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MathiasScore : MonoBehaviour
{
    public static int score = 0;
    public Text scoreText;
    void Start()
    {
        UpdateScoreUI();
    }

    public static void AddScore(int score)
    { 
        score = score + 1;
        UpdateScoreUI();
    }

    public static void UpdateScoreUI()
    {
        if (GameObject.Find("Ennemy") != null)
        { 
            Text scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
            scoreText.text = "Score" + score.ToString();
        }
    }

    
}
