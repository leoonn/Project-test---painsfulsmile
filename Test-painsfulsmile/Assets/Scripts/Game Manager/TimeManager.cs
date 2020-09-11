using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class TimeManager : MonoBehaviour
{
    public  int timeGame;
    public TMP_Text timeText;
    PlayerMove playerScript;
    GameOver gameOverScript;
    void Start()
    {
        playerScript = GameObject.Find("Player").GetComponent<PlayerMove>();
        gameOverScript = GameObject.Find("GameManager").GetComponent<GameOver>();
        PlayerPrefs.SetInt("TimeGame", timeGame);
    }

    // Update is called once per frame
    void Update()
    {
        TimerGame();

    }

    void TimerGame()
    {
        int time = timeGame -= (int)Time.time;

        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time - minutes * 60);

        string textTime = string.Format("{0:0}:{1:00}", minutes, seconds);
        if (timeGame < 0)
        {
            timeGame = 0;
            Time.timeScale = 0;
            playerScript.enabled = false;
            Debug.Log("GameOver");
            gameOverScript.GameOverActive();
        }
        timeText.text = textTime;
    }
}