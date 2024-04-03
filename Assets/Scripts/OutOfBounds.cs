using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBounds : MonoBehaviour
{
  AudioManager audioManager;
  public Canvas GameOverUI; //Reference to Game Over Canvas
  public float yDistanceToShowGameOver = -30.0f; // Adjust this value if needed

    private bool gameIsOver = false;

    private void Update()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        if (!gameIsOver && transform.position.y < yDistanceToShowGameOver)
        {
            //Character has gone out of the screen. Show the Game Over Canvas.
            if (GameManager.highScore < GameManager.score)
            {
                GameManager.highScore = GameManager.score;
            }
            GameManager.score = 0;
            Obstacle.bugsEaten = 0;
           
            GameOverUI.gameObject.SetActive(true);
            
        }
    }
}
