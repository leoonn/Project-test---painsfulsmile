using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class TimeManager : MonoBehaviour
{
    float timeGame = 30;
    public TMP_Text timeText;
    PlayerMove playerScript;
    GameOver gameOverScript;

    private void Awake()
    {
        timeGame = PlayerPrefs.GetFloat("Time", 0 );
    }
    void Start()
    {
        playerScript = GameObject.Find("Player").GetComponent<PlayerMove>();
        gameOverScript = GameObject.Find("GameManager").GetComponent<GameOver>();
        
    }

    // Update is called once per frame
    void Update()
    {
        TimerGame();

    }

    void TimerGame()
    {
        float time = timeGame -= Time.deltaTime;

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