using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour
{
    public GameObject playerPrefab;
    public Text continueText;
    public Text scoreText;
    //public int bugsEaten = 0;
    static public int score;
    static public int highScore;
    private float timeElapsed = 0f;
    private float bestTime = 0f;
    //private int highScore = 0;
    private float blinkTime = 0f;
    private bool blink;
    private bool gameStarted;
    private TimeManager timeManager;
    private GameObject player;
    private GameObject frog;
    //private GameObject floor;
   // private Spawner spawner;
    private bool beatBestTime;
    private bool beatBestScore;
    private Obstacle obstacle;


    private void Awake()
    {
        //floor = GameObject.Find("Foreground");
        //spawner = GameObject.Find("Spawner").GetComponent<Spawner>();
        timeManager = GetComponent<TimeManager>();
        obstacle = GetComponent<Obstacle>();
        frog = GameObject.Find("Frog");
    }
    // Start is called before the first frame update
    void Start()
    {
        /*var floorHeight = floor.transform.localScale.y;

        var pos = floor.transform.position;
        pos.x = 0;
        pos.y = -((Screen.height / PixelPerfectCamera.pixelsToUnits) / 2) + (floorHeight / 2);
        floor.transform.position = pos;

        spawner.active = false;*/

        //ResetGame();
        //Time.timeScale = 0;

        //continueText.text = "PRESS ANY BUTTON TO START";

        bestTime = PlayerPrefs.GetFloat("BestTime");
    }

    // Update is called once per frame
    void Update()
    {

        //int score = GameObject.Find("bugs").GetComponent<Obstacle>().bugsEaten;
        score = Obstacle.bugsEaten;
        if (!gameStarted && Time.timeScale == 0)
        {
            if (Input.anyKeyDown)
            {
                timeManager.ManipulateTime(1, 1f);
               // ResetGame();
            }
        }

        if (!gameStarted)
        {
            blinkTime++;

            if (blinkTime % 40 == 0)
            {
                blink = !blink;

            }
            continueText.canvasRenderer.SetAlpha(blink ? 0 : 1);
            var textColor = beatBestTime ? "#FF)" : "#FFF";
            //scoreText.text = "TIME: " + FormatTime(timeElapsed) + "\n<color=" + textColor + ">BEST: " + FormatTime(bestTime) + "</color>";
            scoreText.text = "BUGS EATEN: " + score + "\n<color=" + textColor + ">BEST: " + FormatTime(bestTime) + "</color>";
            
        }
        else
        {
            timeElapsed += Time.deltaTime;
            scoreText.text = "TIME: " + FormatTime(timeElapsed);
        }

        /*if(frog.transform.position.y < -3)
        {
            //ResetGame();
        }*/
    }
    void OnPlayerKilled()
    {
        //spawner.active = false;

        var playerDestroyScript = player.GetComponent<DestroyOffscreen>();
        playerDestroyScript.DestroyCallback -= OnPlayerKilled;

        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        timeManager.ManipulateTime(0, 5.5f);
        gameStarted = false;

        continueText.text = "PRESS ANY BUTTON TO RESTART";

        /*if (timeElapsed > bestTime)
        {
            bestTime = timeElapsed;
            PlayerPrefs.SetFloat("BestTime", bestTime);
            beatBestTime = true;
        }*/
        if (score > highScore)
        {
            highScore = score;
            //PlayerPrefs.SetFloat("BestTime", bestTime);
            beatBestScore = true;
        }
    }
   /* void ResetGame()
    {
       // spawner.active = true;

        player = GameObjectUtil.Instantiate(playerPrefab, new Vector3(0, (Screen.height / PixelPerfectCamera.pixelsToUnits) / 2 + 100, 0));

        var playerDestroyScript = player.GetComponent<DestroyOffscreen>();
        playerDestroyScript.DestroyCallback += OnPlayerKilled;

        gameStarted = true;

        continueText.canvasRenderer.SetAlpha(0);

        timeElapsed = 0;
        beatBestTime = false;
        beatBestScore = false;
    }*/

    string FormatTime(float value)
    {
        TimeSpan t = TimeSpan.FromSeconds(value);

        return string.Format("{0:D2}:{1:D2}", t.Minutes, t.Seconds);
        //return value.ToString();
    }
}
