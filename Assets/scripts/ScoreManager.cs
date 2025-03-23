using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class ScoreManager : MonoBehaviour
{
    [Header("UI References (TMP)")]
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;

    private int currentScore = 0;
    private int highScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        LoadHighScore(); // Cargar el récord al inicio
        UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddScore(int points)
    {
        currentScore += points;
        if (currentScore > highScore)
        {
            highScore = currentScore;
            SaveHighScore();
        }
        UpdateUI();
    }

    void UpdateUI()
    {
        scoreText.text = $"Score: {currentScore}";
        highScoreText.text = $"High Score: {highScore}";
    }

    void SaveHighScore() => PlayerPrefs.SetInt("HighScore", highScore);

    void LoadHighScore() => highScore = PlayerPrefs.GetInt("HighScore", 0);
}
