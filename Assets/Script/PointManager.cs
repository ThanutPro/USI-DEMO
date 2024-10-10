using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointManager : MonoBehaviour
{
    public int score;
    public TMP_Text scoreText;

    public TMP_Text finalScoreText;
    public TMP_Text highScoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score: " + score;
        // Load high score at the start
        LoadHighScore();
    }

    public void UpdateScore(int points)
    {
        score += points;
        scoreText.text = "Score: " + score;
    }

    public void HighScoreUpdate()
    {
        if (score > PlayerPrefs.GetInt("SavedHighScore", 0)) // Default to 0 if no high score saved
        {
            PlayerPrefs.SetInt("SavedHighScore", score); // Corrected from playerPrefs to PlayerPrefs
        }

        finalScoreText.text = "Score: " + score.ToString();
        highScoreText.text = "HighScore: " + PlayerPrefs.GetInt("SavedHighScore").ToString();
    }

    private void LoadHighScore()
    {
        highScoreText.text = "HighScore: " + PlayerPrefs.GetInt("SavedHighScore", 0).ToString(); // Load high score when starting
    }
}
