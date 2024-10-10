using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverScreen : MonoBehaviour
{
    public GameObject gameOverPanel; // Reference to the Game Over UI panel
    public TMP_Text scoreText; // Reference to the TMP_Text for displaying the score
    public TMP_Text highScoreText; // Reference to the TMP_Text for displaying the high score
    private PointManager pointManager; // Reference to PointManager

    private void Awake()
    {
        gameOverPanel.SetActive(false); // Ensure the Game Over panel is hidden at the start
        pointManager = FindObjectOfType<PointManager>(); // Find the PointManager in the scene
    }

    public void Setup()
    {
        gameOverPanel.SetActive(true); // Show the Game Over panel

        // Update the score and high score text
        scoreText.text = "Score: " + pointManager.score.ToString();
        highScoreText.text = "High Score: " + PlayerPrefs.GetInt("SavedHighScore", 0).ToString();
    }

    public void RestartGame()
    {
        // Restart the game
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main"); // Replace "Main" with the name of your main scene
    }
}
