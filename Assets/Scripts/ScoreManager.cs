
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    public Obstacle obstacle;

    public Transform player; // Reference to the player's transform
    private float distanceTraveled; // To store the distance traveled

    public Text scoreText;
    public Text highscoreText;

    public Canvas gameOverCanvas; // Reference to the Canvas component

    int score = 0;
    int highscore = 0;

    // Start is called before the first frame update
    void Start()
    {
        distanceTraveled = 0f;

        // Load the high score from PlayerPrefs
        highscore = PlayerPrefs.GetInt("highscore", 0);

        // Updates the high score text in the UI
        highscoreText.text = "HIGHSCORE: " + highscore.ToString();

        // Ensure the Canvas component is initially disabled
        gameOverCanvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.position.y >= -30.0f)
        {
            // Calculate the distance traveled if the player is still above -30.0f
            distanceTraveled = player.position.x + (Obstacle.bugsEaten * 200);

            // Update the score text continuously
            scoreText.text = "SCORE " + Mathf.Floor(distanceTraveled + (Obstacle.bugsEaten * 200));

            // Update the high score if a new high score is achieved
            if (distanceTraveled > highscore)
            {
                highscore = Mathf.FloorToInt(distanceTraveled);
                highscoreText.text = "HIGHSCORE: " + highscore.ToString();

                // Save the high score using PlayerPrefs
                PlayerPrefs.SetInt("highscore", highscore);
                PlayerPrefs.Save();
            }
        }
        else
        {
            // The player has gone below -30.0f, so it's game over
            GameOver();
        }
    }

    void GameOver()
    {
        // Update the UI text with the final score
        scoreText.text = "SCORE: " + Mathf.Floor(distanceTraveled);

        // Activate the Canvas component within the Game Over UI
        gameOverCanvas.enabled = true;

        // Save the high score using PlayerPrefs (again, in case it was updated)
        PlayerPrefs.SetInt("highscore", highscore);
        PlayerPrefs.Save();
    }
}

