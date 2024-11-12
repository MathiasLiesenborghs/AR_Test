using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MathiasScoreGain : MonoBehaviour
{
    public int points = 1;  
    private MathiasScore scoreManager;

    void Start()
    {
        
        scoreManager = FindObjectOfType<MathiasScore>();
    }

    void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Projectile"))
        {
            Destroy(gameObject);
            scoreManager.AddScore(points);
        }
    }
}
