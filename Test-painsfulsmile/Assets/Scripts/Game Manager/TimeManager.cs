using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TimeManager : MonoBehaviour
{
    public static float timeGame;
    public Text timeText;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         
       float time = timeGame -= Time.deltaTime;

        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time - minutes * 60);

        string textTime = string.Format("{0:0}:{1:00}", minutes, seconds);
        if (timeGame < 0)
        {
            timeGame = 0;

        }
        timeText.text = textTime;
    }
}
